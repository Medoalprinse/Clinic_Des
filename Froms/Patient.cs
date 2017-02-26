using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Froms
{
    public partial class Patient : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private int patientID;
        private List<int> followUps;

        private int followUpID = 0;
        private DateTime lmp;

        public Patient()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        public Patient(int id)
            : this()
        {
            this.patientID = id;
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            loadPatientInfo();
            getFollowUps();

            if (followUps.Count > 0)
                combo_followUps.SelectedIndex = 0;
        }

        private void getFollowUps()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Follow_Up WHERE Follow_Up.patient_id = @id ORDER BY start_date DESC";
                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", patientID);
                OleDbDataReader dr = command.ExecuteReader();

                followUps = new List<int>();
                combo_followUps.Items.Clear();
                while (dr.Read())
                {
                    followUps.Add(dr.GetInt32(dr.GetOrdinal("follow_up_id")));
                    combo_followUps.Items.Add(dr.GetDateTime(dr.GetOrdinal("start_date")).ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured !!!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void loadPatientInfo()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Patient WHERE Patient.patient_id = @id";
                // AND Patient.patient_id = Follow_Up.patient_id
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@id", patientID);

                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txt_patientID.Text = patientID.ToString();
                    txt_patientName.Text = dr["patient_name"].ToString();
                    txt_husbandName.Text = dr["husband_name"].ToString();
                    txt_phone.Text = dr["phone"].ToString();

                    int colIndex = 0;
                    colIndex = dr.GetOrdinal("patient_bdate");
                    num_patientAge.Text = calcAge(dr.GetDateTime(colIndex));
                    colIndex = dr.GetOrdinal("husband_bdate");
                    num_husbandAge.Text = calcAge(dr.GetDateTime(colIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured !!!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private string calcAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age.ToString();
        }

        private void combo_followUps_DropDown(object sender, EventArgs e)
        {
            getFollowUps();
        }

        private void combo_followUps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                //Do not reject the input
                e.Handled = false;
            else
                //Reject the input
                e.Handled = true;
        }

        private void combo_followUps_SelectedIndexChanged(object sender, EventArgs e)
        {
            followUpID = followUps[combo_followUps.SelectedIndex];

            getFollowUp();
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
                    txt_parityA.Text = dr.GetInt32(dr.GetOrdinal("parity_a")).ToString();
                    txt_parityB.Text = dr.GetInt32(dr.GetOrdinal("parity_b")).ToString();

                    lmp = dr.GetDateTime(dr.GetOrdinal("lmp"));
                    txt_lmp.Text = lmp.ToString("dd/MM/yyyy");

                    DateTime edd = dr.GetDateTime(dr.GetOrdinal("lmp"));
                    edd = edd.AddMonths(9).AddDays(7);
                    txt_edd.Text = edd.ToString("dd/MM/yyyy");

                    txt_living.Text = dr.GetInt32(dr.GetOrdinal("living")).ToString();
                    txt_male.Text = dr.GetInt32(dr.GetOrdinal("male")).ToString();
                    txt_female.Text = dr.GetInt32(dr.GetOrdinal("female")).ToString();

                    txt_rh.Text = dr[dr.GetOrdinal("rh")].ToString();

                    txt_menarchal.Text = dr.GetInt32(dr.GetOrdinal("menarchal")) + " Years Old";
                    txt_cycleD.Text = dr.GetInt32(dr.GetOrdinal("cycle_d")).ToString();
                    txt_cycleC.Text = dr.GetInt32(dr.GetOrdinal("cycle_c")).ToString();
                    rtxt_notes.Text = dr[dr.GetOrdinal("notes")].ToString();

                    getPastHistory();
                    getFamilyHistory();
                    getPregnancy();
                    getAbortion();
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

        private void getAbortion()
        {
            try
            {
                String sql = "SELECT * FROM Parity_Abortion WHERE follow_up_id = @id";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_PastHistory.Items.Clear();
                while (dr.Read())
                {
                    listBox_abortion.Items.Add(dr[dr.GetOrdinal("hValue")]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void getPregnancy()
        {
            try
            {
                String sql = "SELECT * FROM Parity_Preg WHERE follow_up_id = @id";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_PastHistory.Items.Clear();
                while (dr.Read())
                {
                    listBox_preg.Items.Add(dr[dr.GetOrdinal("hValue")]);
                }
            }
            catch (Exception)
            {
                throw;
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

                listBox_PastHistory.Items.Clear();
                while (dr.Read())
                {
                    listBox_PastHistory.Items.Add(dr[dr.GetOrdinal("hName")]);
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
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_addFollowUpLink_Click(object sender, EventArgs e)
        {
            Add_new_Follow_Up form = new Add_new_Follow_Up(patientID);
            form.Show();
        }

        private void btn_addVisitLink_Click(object sender, EventArgs e)
        {
            if (followUpID == 0)
            {
                MessageBox.Show("Please select a follow up");
                return;
            }

            AddNewVisit form = new AddNewVisit(patientID, followUpID, lmp, txt_patientName.Text);
            form.Show();
        }

        private void btn_viewVisitsLink_Click(object sender, EventArgs e)
        {
            if (followUpID == 0)
            {
                MessageBox.Show("Please select a follow up");
                return;
            }

            Visits form = new Visits(patientID, followUpID);
            form.Show();
        }

        private void btn_addLabLink_Click(object sender, EventArgs e)
        {
            AddNewLab form = new AddNewLab(patientID);
            form.Show();
        }

        private void btn_viewLabs_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Lab, Values_Lab WHERE patient_id = @pID AND Lab.lab_value_id = Values_Lab.ID ORDER BY lab_date DESC";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@pID", patientID);

                OleDbDataReader dr = command.ExecuteReader();
                ViewLabs form = new ViewLabs(dr);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured !!!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btn_transferLink_Click(object sender, EventArgs e)
        {

            TransferDetails form = new TransferDetails(txt_patientName.Text, num_patientAge.Text);
            form.Show();
        }

        private void btn_editFollowUp_Click(object sender, EventArgs e)
        {
            if (followUpID == 0)
            {
                MessageBox.Show("Please select a follow up");
                return;
            }

            EditFollowUp form = new EditFollowUp(followUpID);
            form.Show();
       
       
        }

        private void listBox_FamilyHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox_PastHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox_preg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
