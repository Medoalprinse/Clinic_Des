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
    public partial class Visits : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private int patientID;
        private int followUpID;
        private List<int> visits;

        public Visits()
        {
            InitializeComponent();
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        public Visits(int patientID, int followUpID)
            : this()
        {
            this.WindowState = FormWindowState.Maximized;
            this.followUpID = followUpID;
            this.patientID = patientID;

            loadWeightsSort();
            LoadMedicationsSort();
            loadLastLabs();
        }

        private void combo_visits_SelectedIndexChanged(object sender, EventArgs e)
        {
            int visitID = visits[combo_visits.SelectedIndex];

            getVisit(visitID);
        }

        private void combo_visits_DropDown(object sender, EventArgs e)
        {
            getVisits();
        }

        private void combo_visits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                //Do not reject the input
                e.Handled = false;
            else
                //Reject the input
                e.Handled = true;
        }

        public String stringValue(String value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return value;
        }


        private void getVisits()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Visit WHERE Visit.follow_up_id = @id ORDER BY visit_date DESC";
                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                visits = new List<int>();
                combo_visits.Items.Clear();
                while (dr.Read())
                {
                    visits.Add(dr.GetInt32(dr.GetOrdinal("visit_id")));
                    combo_visits.Items.Add(dr.GetDateTime(dr.GetOrdinal("visit_date")).ToString("dd/MM/yyyy"));
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

        private void getVisit(int visitID)
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Visit WHERE Visit.visit_id = @id";
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@id", visitID);

                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txt_visitDate.Text = dr.GetDateTime(dr.GetOrdinal("visit_date")).ToString("dd/MM/yyyy");
                    txt_bl_pr_num.Text = dr.GetInt32(dr.GetOrdinal("bl_pr_num")).ToString();
                    txt_bl_pr_dom.Text = dr.GetInt32(dr.GetOrdinal("bl_pr_dom")).ToString();
                    txt_weight.Text = dr.GetInt32(dr.GetOrdinal("weight")).ToString();
                    txt_tmp.Text = dr.GetInt32(dr.GetOrdinal("tmp")).ToString();

                    txt_ultraSound.Text = dr[dr.GetOrdinal("ultra_sound")].ToString();
                    txt_visitNotes.Text = dr[dr.GetOrdinal("notes")].ToString();

                    int days = dr.GetInt32(dr.GetOrdinal("days"));
                    txt_gasAge.Text = (days / 7) + " Week(s) and " + (days % 7) + " Day(s)";

                    getMedications(visitID);
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

        private void getMedications(int visitID)
        {
            try
            {
                String sql = "SELECT * FROM Visit_Medication, Medicine "
                    + "WHERE Visit_Medication.visit_id = @vID AND Visit_Medication.medicine_id = Medicine.medicine_id";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@vID", visitID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_visitMedications.Items.Clear();
                while (dr.Read())
                {
                    String med = dr[dr.GetOrdinal("medicine_name")] + " " + dr[dr.GetOrdinal("concentration")];
                    listBox_visitMedications.Items.Add(med);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void loadWeightsSort()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Visit WHERE follow_up_id = @fID";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@fID", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_allWeights.Items.Clear();
                listBox_allBloodPressures.Items.Clear();
                while (dr.Read())
                {
                    String weight =
                        dr.GetDateTime(dr.GetOrdinal("visit_date")).ToString("dd/MM/yyyy")
                        + " - " + dr[dr.GetOrdinal("weight")] + " kgs";
                    listBox_allWeights.Items.Add(weight);

                    String blPressure =
                        dr.GetDateTime(dr.GetOrdinal("visit_date")).ToString("dd/MM/yyyy")
                        + " - " + dr[dr.GetOrdinal("bl_pr_num")] + " / " + dr[dr.GetOrdinal("bl_pr_dom")];
                    listBox_allBloodPressures.Items.Add(blPressure);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void LoadMedicationsSort()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Medicine WHERE Medicine.medicine_id IN "
                + "(SELECT DISTINCT Visit_Medication.medicine_id FROM Visit_Medication, Visit "
                + "WHERE Visit.follow_up_id = @fID AND Visit.visit_id = Visit_Medication.visit_id)";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@fID", followUpID);
                OleDbDataReader dr = command.ExecuteReader();

                listBox_uniqueMedicines.Items.Clear();
                while (dr.Read())
                {
                    listBox_uniqueMedicines.Items.Add(dr["medicine_name"] + " - " + dr["concentration"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
        }

        private void loadLastLabs()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Lab, Values_Lab "
                + "WHERE Lab.lab_value_id = Values_Lab.ID "
                + "AND lab_id in (SELECT MAX(lab_id) FROM Lab WHERE Lab.patient_id = @pID GROUP BY lab_value_id);";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@pID", patientID);

                OleDbDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string[] row = { 
                                   dr["lab_name"].ToString(), 
                                   dr["lab_result"].ToString(), 
                                   dr.GetDateTime(dr.GetOrdinal("lab_date")).ToString("dd/MM/yyyy")
                               };

                    ListViewItem lvi = new ListViewItem(row);
                    listView_labs.Items.Add(lvi);
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

        private void btn_printVisitAction_Click_1(object sender, EventArgs e)
         {
            List<String> images = new List<string>();

            MessageBox.Show("Please select the visit images");

            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in open.FileNames)
                    images.Add("file:" + item);

            }
        }
    }
}