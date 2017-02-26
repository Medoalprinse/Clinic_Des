using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting;

namespace Clinic.Froms
{

    public partial class TransferPrint : Form
    {
        private String name;
        private String age;
        private String hospName;
        private String reason;
        private String date;
        private String transferDate;
        private string fas;
        private string entry;

        public TransferPrint(String name, String age, String hospName, String reason, String date, String transferDate, String fas, String entry)
        {
            InitializeComponent();

            this.name = name;
            this.age = age;
            this.hospName = hospName;
            this.reason = reason;
            this.date = date;
            this.transferDate = transferDate;
            this.fas = fas;
            this.entry = entry;
        }

        private void TransferPrint_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pName", name), 
                new Microsoft.Reporting.WinForms.ReportParameter("age", age), 
                new Microsoft.Reporting.WinForms.ReportParameter("hospName", hospName), 
                new Microsoft.Reporting.WinForms.ReportParameter("date", date), 
                new Microsoft.Reporting.WinForms.ReportParameter("transfer", reason), 
                new Microsoft.Reporting.WinForms.ReportParameter("transferDate", transferDate),
                new Microsoft.Reporting.WinForms.ReportParameter("fasting", fas), 
                new Microsoft.Reporting.WinForms.ReportParameter("hosEntry", entry)
            };

            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
