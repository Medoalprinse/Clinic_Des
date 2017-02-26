using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Clinic.Froms
{
    public partial class EditFollowUp : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private int followUpID = 0;

        private List<int> pastHistory;
        private List<int> addedPastHistory;
        private List<int> removedPastHistory;
        private List<int> selectedPastHistory;

        private List<int> familyHistory;
        private List<int> addedFamilyHistory;
        private List<int> removedFamilyHistory;
        private List<int> selectedFamilyHistory;

        public EditFollowUp()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);

            addedPastHistory = new List<int>();
            removedPastHistory = new List<int>();
            selectedPastHistory = new List<int>();

            addedFamilyHistory = new List<int>();
            removedFamilyHistory = new List<int>();
            selectedFamilyHistory = new List<int>();
        }

        public EditFollowUp(int followUpID)
            : this()
        {
            this.followUpID = followUpID;

            getFollowUp();
            loadPastHistory();
            loadFamilyHistory();
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || char.IsControl(e.KeyChar))
                //Do not reject the input
                e.Handled = false;
            else
                //Reject the input
                e.Handled = true;
        }

        public int numberValue(String s)
        {
            return Convert.ToInt32(ZeroIfEmpty(s));
        }

        public String ZeroIfEmpty(String s)
        {
            return String.IsNullOrEmpty(s) ? "0" : s;
        }

        public String rhValue()
        {
            if (combo_rh.SelectedIndex < 0)
            {
                MessageBox.Show("RH is not selected");
                return "";
            }

            return combo_rh.SelectedItem.ToString();
        }

        private void getFollowUp()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Follow_Up WHERE Follow_Up.follow_up_id = @id";
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@id", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    date_startDate.Value = dr.GetDateTime(dr.GetOrdinal("start_date"));

                    txt_parityA.Text = dr.GetInt32(dr.GetOrdinal("parity_a")).ToString();
                    txt_parityB.Text = dr.GetInt32(dr.GetOrdinal("parity_b")).ToString();

                    DateTime lmp = dr.GetDateTime(dr.GetOrdinal("lmp"));
                    date_lmp.Value = lmp;

                    DateTime edd = lmp;
                    edd = edd.AddMonths(9).AddDays(7);
                    txt_edd.Text = edd.ToString("dd/MM/yyyy");

                    txt_living.Text = dr.GetInt32(dr.GetOrdinal("living")).ToString();
                    txt_male.Text = dr.GetInt32(dr.GetOrdinal("male")).ToString();
                    txt_female.Text = dr.GetInt32(dr.GetOrdinal("female")).ToString();

                    combo_rh.SelectedItem = dr[dr.GetOrdinal("rh")].ToString();

                    txt_menarchal.Text = dr.GetInt32(dr.GetOrdinal("menarchal")).ToString();
                    txt_cycleD.Text = dr.GetInt32(dr.GetOrdinal("cycle_d")).ToString();
                    txt_cycleC.Text = dr.GetInt32(dr.GetOrdinal("cycle_c")).ToString();

                    getPastHistory();
                    getFamilyHistory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void getPastHistory()
        {
            try
            {
                String sql = "SELECT * FROM Past_History, Values_Past_History "
                + "WHERE follow_up_id = @id AND Past_History.hValue = Values_Past_History.ID";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_pastHistory.Items.Clear();
                while (dr.Read())
                {
                    listBox_pastHistory.Items.Add(dr[dr.GetOrdinal("hName")]);
                    selectedPastHistory.Add(dr.GetInt32(dr.GetOrdinal("hValue")));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void getFamilyHistory()
        {
            try
            {
                String sql = "SELECT * FROM Family_History, Values_Family_History "
                + "WHERE follow_up_id = @id AND Family_History.hValue = Values_Family_History.ID";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_FamilyHistory.Items.Clear();
                while (dr.Read())
                {
                    listBox_FamilyHistory.Items.Add(dr[dr.GetOrdinal("hName")]);
                    selectedFamilyHistory.Add(dr.GetInt32(dr.GetOrdinal("hValue")));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadPastHistory()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Values_Past_History";

                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                pastHistory = new List<int>();
                combo_pastHistory.Items.Clear();
                while (dr.Read())
                {
                    pastHistory.Add(dr.GetInt32(dr.GetOrdinal("ID")));
                    String value = dr.GetString(dr.GetOrdinal("hName"));
                    combo_pastHistory.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void loadFamilyHistory()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Values_Family_History";

                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                familyHistory = new List<int>();
                combo_familyHistory.Items.Clear();
                while (dr.Read())
                {
                    familyHistory.Add(dr.GetInt32(dr.GetOrdinal("ID")));
                    String value = dr.GetString(dr.GetOrdinal("hName"));
                    combo_familyHistory.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void updateFollowUp()
        {
            try
            {
                conn.Open();

                String sql = "UPDATE Follow_Up "
                    + "SET parity_a=@parA, parity_b=@parB, living=@living, male=@male, female=@female, "
                    + "lmp=@lmp, rh=@rh, menarchal=@men, cycle_d=@cycleD, cycle_c=@cycleC, notes=@notes, start_date=@sdate "
                    + "WHERE follow_up_id = @fID";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@parA", numberValue(txt_parityA.Text));
                command.Parameters.AddWithValue("@parB", numberValue(txt_parityB.Text));
                command.Parameters.AddWithValue("@living", numberValue(txt_living.Text));
                command.Parameters.AddWithValue("@male", numberValue(txt_male.Text));
                command.Parameters.AddWithValue("@female", numberValue(txt_female.Text));
                command.Parameters.AddWithValue("@lmp", date_lmp.Value.Date);
                command.Parameters.AddWithValue("@rh", rhValue());
                command.Parameters.AddWithValue("@men", numberValue(txt_menarchal.Text));
                command.Parameters.AddWithValue("@cycleD", numberValue(txt_cycleD.Text));
                command.Parameters.AddWithValue("@cycleC", numberValue(txt_cycleC.Text));
                command.Parameters.AddWithValue("@notes", rtxt_notes.Text);
                command.Parameters.AddWithValue("@sdate", date_startDate.Value.Date.ToString());
                command.Parameters.AddWithValue("@fID", followUpID);

                command.ExecuteNonQuery();

                updateAllPastHistory();
                updateAllFamilyHistory();
                MessageBox.Show("Follow Up updated SUCCESSFULLY");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_pastRefresh_Click(object sender, EventArgs e)
        {
            loadPastHistory();
        }

        private void btn_familyRefresh_Click(object sender, EventArgs e)
        {
            loadFamilyHistory();
        }

        private void btn_editFollowUpAction_Click(object sender, EventArgs e)
        {
            updateFollowUp();
        }

        private void updateAllPastHistory()
        {
            foreach (int selected in addedPastHistory)
                addPastHistory(selected);

            foreach (int removed in removedPastHistory)
                removePastHistory(removed);
        }

        private void updateAllFamilyHistory()
        {
            foreach (int selected in addedFamilyHistory)
                addFamilyHistory(selected);

            foreach (int removed in removedFamilyHistory)
                removeFamilyHistory(removed);
        }


        private void addPastHistory(int selected)
        {
            try
            {
                //                conn.Open();

                String sql = "INSERT INTO Past_History (follow_up_id, hValue) VALUES (@fID, @hValue)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@hValue", selected);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
                //                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removePastHistory(int removed)
        {
            try
            {
                String sql = "DELETE FROM Past_History WHERE ID in "
                    + "(Select max(ID) From Past_History WHERE follow_up_id=@fID AND hValue=@hValue)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@hValue", removed);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        private void addFamilyHistory(int selected)
        {
            try
            {
                String sql = "INSERT INTO Family_History (follow_up_id, hValue) VALUES (@fID, @hValue)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@hValue", selected);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        private void removeFamilyHistory(int removed)
        {
            try
            {
                String sql = "DELETE FROM Family_History WHERE ID in "
                    + "(Select max(ID) From Family_History WHERE follow_up_id=@fID AND hValue=@hValue)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@hValue", removed);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        private void btn_addPHistory_Click(object sender, EventArgs e)
        {
            if (combo_pastHistory.SelectedIndex < 0)
            {
                MessageBox.Show("No value selected");
                return;
            }

            String pHistory = combo_pastHistory.SelectedItem.ToString();
            listBox_pastHistory.Items.Add(pHistory);
            addedPastHistory.Add(pastHistory[combo_pastHistory.SelectedIndex]);
            selectedPastHistory.Add(pastHistory[combo_pastHistory.SelectedIndex]);
        }

        private void btn_removePHistory_Click(object sender, EventArgs e)
        {
            if (listBox_pastHistory.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No item Selected !!!");
                return;
            }

            int intselectedindex = listBox_pastHistory.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                int removedID = selectedPastHistory[intselectedindex];
                listBox_pastHistory.Items.RemoveAt(intselectedindex);
                selectedPastHistory.RemoveAt(intselectedindex);
                removedPastHistory.Add(removedID);
            }
        }

        private void btn_addFHistory_Click(object sender, EventArgs e)
        {
            if (combo_familyHistory.SelectedIndex < 0)
            {
                MessageBox.Show("No value selected");
                return;
            }

            String fHistory = combo_familyHistory.SelectedItem.ToString();
            listBox_FamilyHistory.Items.Add(fHistory);
            addedFamilyHistory.Add(familyHistory[combo_familyHistory.SelectedIndex]);
            selectedFamilyHistory.Add(familyHistory[combo_familyHistory.SelectedIndex]);
        }

        private void btn_removeFHistory_Click(object sender, EventArgs e)
        {
            if (listBox_FamilyHistory.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No item Selected !!!");
                return;
            }

            int intselectedindex = listBox_FamilyHistory.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                int removedID = selectedFamilyHistory[intselectedindex];
                listBox_FamilyHistory.Items.RemoveAt(intselectedindex);
                selectedFamilyHistory.RemoveAt(intselectedindex);
                removedFamilyHistory.Add(removedID);
            }
        }

        private void date_lmp_ValueChanged(object sender, EventArgs e)
        {
            DateTime edd = date_lmp.Value;
            edd = edd.AddMonths(9).AddDays(7);
            txt_edd.Text = edd.ToString("dd/MM/yyyy");
        }

    }
}
