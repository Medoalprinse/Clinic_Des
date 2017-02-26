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
using System.Data.SqlClient;
using Clinic.Froms;

namespace Clinic
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        public static int patientID;

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            patientID = -1;
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        private string calcAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age.ToString();
        }

        private void btn_addAction_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "INSERT INTO Patient "
                    + "(patient_name, patient_bdate, husband_name, husband_bdate, phone) "
                    + "VALUES(@name, @bdate, @hName, @hBDate, @phone)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", txt_patientName.Text);
                command.Parameters.AddWithValue("@bdate", date_patientBDate.Value.Date);
                command.Parameters.AddWithValue("@hName", txt_husbandName.Text);
                command.Parameters.AddWithValue("@hBDate", date_husbandBDate.Value.Date);
                command.Parameters.AddWithValue("@phone", txt_phone.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Patient added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
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

        private void btn_searchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Patient WHERE patient_name LIKE @name AND phone LIKE @phone";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", "%" + txt_patientSearchName.Text + "%");
                command.Parameters.AddWithValue("@phone", "%" + txt_patientSearchPhone.Text + "%");

                OleDbDataReader dr = command.ExecuteReader();
                Select_Patient sp = new Select_Patient(dr);
                sp.Show();
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

        private void btn_searchByID_Click(object sender, EventArgs e)
        {
            if (txt_patientID.Text == "")
            {
                MessageBox.Show("Please Enter the patient ID", "No Input Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            patientID = Convert.ToInt32(txt_patientID.Text);
            loadPatient();
        }

        private void btn_addLabLink_Click(object sender, EventArgs e)
        {
            AddLabValue form = new AddLabValue();
            form.Show();
        }

        private void btn_addPastHistValue_Click(object sender, EventArgs e)
        {
            AddPastHistory form = new AddPastHistory();
            form.Show();
        }

        private void btn_addFamHistValue_Click(object sender, EventArgs e)
        {
            AddFamilyHistory form = new AddFamilyHistory();
            form.Show();
        }

        private void btn_addMedicineLink_Click(object sender, EventArgs e)
        {
            AddNewMedicine form = new AddNewMedicine();
            form.Show();
        }

        private void date_updateBD_ValueChanged(object sender, EventArgs e)
        {
            txt_updatedPatAge.Text = calcAge(date_updateBD.Value);
        }

        private void date_updateHusbandBD_ValueChanged(object sender, EventArgs e)
        {
            txt_updatedHusbandAge.Text = calcAge(date_updateHusbandBD.Value);
        }

        public void loadPatient()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Patient WHERE patient_id = @pID";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@pID", patientID);
                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    patientID = dr.GetInt32(dr.GetOrdinal("patient_id")); 
                    txt_viewPatientID.Text = patientID.ToString();
                    txt_updateName.Text = dr["patient_name"].ToString();
                    txt_updateHusbandName.Text = dr["husband_name"].ToString();
                    txt_updatePhone.Text = dr["phone"].ToString();

                    DateTime age = dr.GetDateTime(dr.GetOrdinal("patient_bdate"));
                    date_updateBD.Value = age;
                    txt_updatedPatAge.Text = calcAge(age);

                    age = dr.GetDateTime(dr.GetOrdinal("husband_bdate"));
                    date_updateHusbandBD.Value = age;
                    txt_updatedHusbandAge.Text = calcAge(age);

                    MessageBox.Show("Patient info Loaded SUCCESSFULLY");
                }
                else
                {
                    MessageBox.Show("This ID does NOT exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_updatePatientAction_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "UPDATE Patient "
                    + "SET patient_name=@name, patient_bdate=@bdate, husband_name=@hName, husband_bdate=@hBDate, phone=@phone "
                    + "WHERE patient_id=@pID";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", txt_updateName.Text);
                command.Parameters.AddWithValue("@bdate", date_updateBD.Value.Date);
                command.Parameters.AddWithValue("@hName", txt_updateHusbandName.Text);
                command.Parameters.AddWithValue("@hBDate", date_updateHusbandBD.Value.Date);
                command.Parameters.AddWithValue("@phone", txt_updatePhone.Text);
                command.Parameters.AddWithValue("@pID", patientID);

                command.ExecuteNonQuery();
                MessageBox.Show("Patient updated SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void getPatient_TextChanged(object sender, EventArgs e)
        {
            txt_viewPatientID.Text = "";
            txt_updateName.Text = "";
            txt_updateHusbandName.Text = "";
            txt_updatePhone.Text = "";

            date_updateBD.Value = DateTime.Now;
            txt_updatedPatAge.Text = "0";

            date_updateHusbandBD.Value = DateTime.Now;
            txt_updatedHusbandAge.Text = "0";
        }

        private void btn_viewProfileLink_Click(object sender, EventArgs e)
        {
            Patient form = new Patient(patientID);
            form.Show();
        }

        private void btn_deletePaientAction_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                String sql = "DELETE FROM Patient WHERE patient_id=@pID";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", patientID);

                command.ExecuteNonQuery();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
