using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Clinic.Froms
{
    public partial class PrescriptionPrint : Form
    {
        private List<string> meds;
        private List<string> doses;
        private List<string> images;

        private String date;
        private String notes;
        private String patientName;

        public PrescriptionPrint()
        {
            InitializeComponent();
            this.reportViewer.LocalReport.EnableExternalImages = true;
        }

        public PrescriptionPrint(List<string> meds, List<string> doses, List<string> images)
            : this()
        {
            this.meds = meds;
            this.doses = doses;
            this.images = images;
        }

        public PrescriptionPrint(List<string> meds, List<string> doses, List<string> images, string patientName, string notes, String date)
            : this()
        {
            this.meds = meds;
            this.doses = doses;
            this.images = images;

            this.patientName = patientName;
            this.notes = notes;
            this.date = date;
        }

        private void PrescriptionPrint_Load(object sender, EventArgs e)
        {
            ReportParameter[] para = new ReportParameter[(meds.Count * 2) + images.Count + 3];

            for (int i = 0; i < meds.Count; i++)
            {
                para[2 * i] = new ReportParameter("med" + (i + 1), meds[i]);
                para[2 * i + 1] = new ReportParameter("dose" + (i + 1), doses[i]);
            }

            for (int i = 0; i < images.Count; i++)
            {
                para[(meds.Count * 2) + i] = new ReportParameter("image" + (i + 1), images[i]);
            }

            para[(meds.Count * 2) + images.Count] = new ReportParameter("notes", notes);
            para[(meds.Count * 2) + images.Count + 1] = new ReportParameter("patName", patientName);
            para[(meds.Count * 2) + images.Count + 2] = new ReportParameter("date", date);

            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
