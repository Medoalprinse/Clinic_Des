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
    public partial class AddNewMedicine : Form
    {
        OleDbConnection conn;
        String connectionStr;

        public AddNewMedicine()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        public int numberValue(String s)
        {
            return Convert.ToInt32(ZeroIfEmpty(s));
        }

        public String ZeroIfEmpty(String s)
        {
            return String.IsNullOrEmpty(s) ? "0" : s;
        }

        private void btn_addMedicineAction_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Medicine "
                    + "(medicine_name, type, dose, concentration) "
                    + "VALUES (@name, @type, @dose, @conc)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", txt_medName.Text);
                command.Parameters.AddWithValue("@type", txt_type.Text);
                command.Parameters.AddWithValue("@dose", txt_dose.Text);
                command.Parameters.AddWithValue("@conc", txt_conc.Text);

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);
                int id = (int)command.ExecuteScalar();

                MessageBox.Show("The Medicine is added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
