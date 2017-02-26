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
    public partial class AddLabValue : Form
    {
        OleDbConnection conn;
        String connectionStr;

        public AddLabValue()
        {
            InitializeComponent();
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        private void btn_addLabValueAction_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "INSERT INTO Values_Lab "
                    + "(lab_name, normal_range) "
                    + "VALUES (@name, @nRange)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", txt_labName.Text);
                command.Parameters.AddWithValue("@nRange", txt_normalRange.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Lab added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
