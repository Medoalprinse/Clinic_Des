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
    public partial class AddNewLab : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private List<int> labs;
        private List<String> normalRange;

        private int patientID;

        public AddNewLab()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);

            labs = new List<int>();
            normalRange = new List<string>();

            loadLabs();
        }

        public AddNewLab(int patientID)
            : this()
        {
            this.patientID = patientID;
        }

        private void btn_addLabAction_Click(object sender, EventArgs e)
        {
            if(combo_labName.SelectedIndex < 0)
            {
                MessageBox.Show("No Lab is selected", "Error Occured!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            addLab();
        }

        private int addLab()
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Lab "
                    + "(lab_value_id, lab_result, patient_id) "
                    + "VALUES (@l_value, @lResult, @pID)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@l_value", labs[combo_labName.SelectedIndex]);
                command.Parameters.AddWithValue("@lResult", txt_labResult.Text);
                command.Parameters.AddWithValue("@fID", patientID);

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);
                int id = (int)command.ExecuteScalar();
                MessageBox.Show("The Lab is added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void loadLabs()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Values_Lab";

                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                labs= new List<int>();
                normalRange = new List<string>();
                combo_labName.Items.Clear();
                while (dr.Read())
                {
                    labs.Add(dr.GetInt32(dr.GetOrdinal("ID")));
                    normalRange.Add(dr.GetString(dr.GetOrdinal("normal_range")));

                    String value = dr.GetString(dr.GetOrdinal("lab_name"));
                    combo_labName.Items.Add(value);
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

        private void combo_labName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_normalRange.Text = normalRange[combo_labName.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadLabs();
        }

    }
}
