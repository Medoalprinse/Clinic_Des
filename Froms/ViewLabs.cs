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
    public partial class ViewLabs : Form
    {
        private OleDbDataReader dr;

        public ViewLabs()
        {
            InitializeComponent();
        }

        public ViewLabs(OleDbDataReader dr)
            : this()
        {
            this.dr = dr;
            loadLabs();
        }

        public void loadLabs()
        {
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
    }
}
