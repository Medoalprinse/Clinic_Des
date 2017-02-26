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
    public partial class AddPastHistory : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        public AddPastHistory()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        private void btn_addValue_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Values_Past_History (hName) VALUES (@value)";

                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@value", txt_value.Text);
                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);
                int id = (int)command.ExecuteScalar();

                MessageBox.Show("The Value is added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
