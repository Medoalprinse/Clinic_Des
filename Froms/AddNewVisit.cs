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
    public partial class AddNewVisit : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private int followUpID;
        private int patientID;
        private DateTime lmp;
        private int days;

        private List<int> medicines;
        private List<int> selectedMedications;
        private string patientName;

        public AddNewVisit()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);

            medicines = new List<int>();
            selectedMedications = new List<int>();
            loadMedicines();
        }

        public AddNewVisit(int patientID, int followUpID, DateTime lmp, String patientName)
            : this()
        {
            this.patientID = patientID;
            this.followUpID = followUpID;
            this.lmp = lmp;
            this.patientName = patientName;

            DateTime now = DateTime.Today;
            days = (now - lmp).Days;
            txt_gasAge.Text = (days / 7) + " Week(s) and " + (days % 7) + " Day(s)";
        }

        private void loadMedicines()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Medicine";
                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                medicines = new List<int>();
                combo_medication.Items.Clear();
                while (dr.Read())
                {
                    medicines.Add(dr.GetInt32(dr.GetOrdinal("medicine_id")));
                    String med = dr[dr.GetOrdinal("medicine_name")] + " " + dr[dr.GetOrdinal("concentration")] + " " + dr[dr.GetOrdinal("type")];
                    combo_medication.Items.Add(med);
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

        public int numberValue(String s)
        {
            return Convert.ToInt32(ZeroIfEmpty(s));
        }

        public String ZeroIfEmpty(String s)
        {
            return String.IsNullOrEmpty(s) ? "0" : s;
        }

        public String stringValue(String value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return value;
        }

        private void btn_addVisitAction_Click(object sender, EventArgs e)
        {
            int visitID = addVisit();
        }

        private int addVisit()
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Visit "
                    + "(weight, bl_pr_num, bl_pr_dom, tmp, ultra_sound, notes, follow_up_id, visit_date) "
                    + "VALUES (@weight, @bl_num, @bl_dom, @tmp, @ultra, @notes, @fID, @vdate)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@weight", numberValue(txt_weight.Text));
                command.Parameters.AddWithValue("@bl_num", numberValue(txt_bl_pr_num.Text));
                command.Parameters.AddWithValue("@bl_dom", numberValue(txt_bl_pr_dom.Text));
                command.Parameters.AddWithValue("@tmp", numberValue(txt_tmp.Text));
                command.Parameters.AddWithValue("@ultra", stringValue(txt_ultraSound.Text));
                command.Parameters.AddWithValue("@notes", stringValue(txt_notes.Text));
                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@vdate", date_visitDate.Value.Date.ToString());

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);
                int id = (int)command.ExecuteScalar();

                addVisitMedications(id);
                MessageBox.Show("The visit is added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conn.Close();
            }
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
                ViewLabs form = new ViewLabs(dr);
                form.Show();
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

        private void addVisitMedications(int visitID)
        {
            for (int i = 0; i < listBox_visitMedications.Items.Count; i++)
                addVisitMedication(visitID, selectedMedications[i]);
        }

        private void addVisitMedication(int visitID, int medicineID)
        {
            try
            {
                String sql = "INSERT INTO Visit_Medication (visit_id, medicine_id) VALUES (@vID, @mID)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@vID", visitID);
                command.Parameters.AddWithValue("@mID", medicineID);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
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

        private void btn_addMedication_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combo_medication.Text))
            {
                MessageBox.Show("No medicine selected");
                return;
            }

            String med = combo_medication.Text.ToString();
            listBox_visitMedications.Items.Add(med);
            selectedMedications.Add(medicines[combo_medication.SelectedIndex]);
        }

        private void btn_removeMedication_Click(object sender, EventArgs e)
        {
            if (listBox_visitMedications.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No medicine Selected !!!");
                return;
            }

            int intselectedindex = listBox_visitMedications.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                listBox_visitMedications.Items.RemoveAt(intselectedindex);
                selectedMedications.RemoveAt(intselectedindex);
            }
        }

        private void btn_printVisitAction_Click(object sender, EventArgs e)
        {
            List<String> images = new List<string>();

            MessageBox.Show("Please select the visit images");

            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in open.FileNames)
                    images.Add("file:"+item);
            }

            List<String> meds = new List<string>();
            List<String> doses = new List<string>();

            getSelectedMedicinesValues(out meds, out doses);

            using (PrescriptionPrint frm = new PrescriptionPrint(meds, doses, images, patientName, txt_notes.Text, date_visitDate.Value.ToString("dd/MM/yyyy")))
            {
                frm.ShowDialog();
            }

        }

        private void getSelectedMedicinesValues(out List<string> meds, out List<string> doses)
        {
            meds = new List<string>();
            doses = new List<string>();

            try
            {
                if (selectedMedications.Count == 0)
                    return;
                String[] parameters = new String[selectedMedications.Count];
                OleDbCommand cmd = new OleDbCommand();
                for (int i = 0; i < selectedMedications.Count; i++)
                {
                    parameters[i] = string.Format("@id{0}", i);
                    cmd.Parameters.AddWithValue(parameters[i], selectedMedications[i]);
                }

                conn.Open();
                String sql = string.Format("SELECT * FROM Medicine WHERE medicine_id IN ({0})", string.Join(", ", parameters));
                cmd.CommandText = sql;
                cmd.Connection = conn;

                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    String med = dr[dr.GetOrdinal("medicine_name")] + " " + dr[dr.GetOrdinal("concentration")] + " " + dr[dr.GetOrdinal("type")];
                    meds.Add(med);
                    doses.Add(dr[dr.GetOrdinal("dose")].ToString());
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

        private void btn_medRefresh_Click(object sender, EventArgs e)
        {
            loadMedicines();
        }

        private void btn_addLabLink_Click(object sender, EventArgs e)
        {
            AddNewLab form = new AddNewLab(patientID);
            form.Show();
        }

        private void btn_viewLabsLink_Click(object sender, EventArgs e)
        {
            loadLastLabs();
        }

    }
}
