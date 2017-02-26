using Clinic.Froms;
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

namespace Clinic
{
    public partial class Select_Patient : Form
    {
        private OleDbDataReader dr;

        public Select_Patient()
        {
            InitializeComponent();
        }

        public Select_Patient(OleDbDataReader dr)
        {
            InitializeComponent();
            this.dr = dr;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No Patient Selected !!!");
                return;
            }
            int intselectedindex = listView.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
    //            if (Int32.TryParse(TextBoxD1.Text, out x))
                int id = Int32.Parse(listView.Items[intselectedindex].Text);

//                Form1.patientID = id;

                this.Close();
            }
        }

        private void Select_Patient_Load(object sender, EventArgs e)
        {
            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem(dr["patient_id"].ToString());
                lvi.SubItems.Add(dr["patient_name"].ToString());
                lvi.SubItems.Add(dr["phone"].ToString());
                listView.Items.Add(lvi);
            }

        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btn_select_Click(sender, e);
            //}
        }

    }
}
