namespace Clinic.Froms
{
    partial class AddNewVisit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_ultraSound = new System.Windows.Forms.TextBox();
            this.txt_bl_pr_num = new System.Windows.Forms.TextBox();
            this.txt_weight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_bl_pr_dom = new System.Windows.Forms.TextBox();
            this.txt_gasAge = new System.Windows.Forms.TextBox();
            this.txt_tmp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_medication = new System.Windows.Forms.ComboBox();
            this.btn_addMedication = new System.Windows.Forms.Button();
            this.btn_removeMedication = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.listBox_visitMedications = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_printVisitAction = new System.Windows.Forms.Button();
            this.btn_addVisitAction = new System.Windows.Forms.Button();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.btn_medRefresh = new System.Windows.Forms.Button();
            this.date_visitDate = new System.Windows.Forms.DateTimePicker();
            this.btn_addLabLink = new System.Windows.Forms.Button();
            this.btn_viewLabsLink = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txt_ultraSound
            // 
            this.txt_ultraSound.Location = new System.Drawing.Point(349, 170);
            this.txt_ultraSound.Multiline = true;
            this.txt_ultraSound.Name = "txt_ultraSound";
            this.txt_ultraSound.Size = new System.Drawing.Size(296, 72);
            this.txt_ultraSound.TabIndex = 8;
            // 
            // txt_bl_pr_num
            // 
            this.txt_bl_pr_num.Location = new System.Drawing.Point(82, 102);
            this.txt_bl_pr_num.Name = "txt_bl_pr_num";
            this.txt_bl_pr_num.Size = new System.Drawing.Size(41, 20);
            this.txt_bl_pr_num.TabIndex = 3;
            this.txt_bl_pr_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(82, 60);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(41, 20);
            this.txt_weight.TabIndex = 2;
            this.txt_weight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Visit\r\nDate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Blood\r\nPressure";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gastitional Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "/";
            // 
            // txt_bl_pr_dom
            // 
            this.txt_bl_pr_dom.Location = new System.Drawing.Point(147, 102);
            this.txt_bl_pr_dom.Name = "txt_bl_pr_dom";
            this.txt_bl_pr_dom.Size = new System.Drawing.Size(41, 20);
            this.txt_bl_pr_dom.TabIndex = 4;
            this.txt_bl_pr_dom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // txt_gasAge
            // 
            this.txt_gasAge.Enabled = false;
            this.txt_gasAge.Location = new System.Drawing.Point(353, 25);
            this.txt_gasAge.Name = "txt_gasAge";
            this.txt_gasAge.Size = new System.Drawing.Size(127, 20);
            this.txt_gasAge.TabIndex = 5;
            // 
            // txt_tmp
            // 
            this.txt_tmp.Location = new System.Drawing.Point(353, 61);
            this.txt_tmp.Name = "txt_tmp";
            this.txt_tmp.Size = new System.Drawing.Size(63, 20);
            this.txt_tmp.TabIndex = 6;
            this.txt_tmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Temperature";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "° C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Kilograms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ultra Sound";
            // 
            // combo_medication
            // 
            this.combo_medication.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_medication.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_medication.FormattingEnabled = true;
            this.combo_medication.Location = new System.Drawing.Point(25, 314);
            this.combo_medication.Name = "combo_medication";
            this.combo_medication.Size = new System.Drawing.Size(280, 21);
            this.combo_medication.TabIndex = 9;
            // 
            // btn_addMedication
            // 
            this.btn_addMedication.Location = new System.Drawing.Point(49, 341);
            this.btn_addMedication.Name = "btn_addMedication";
            this.btn_addMedication.Size = new System.Drawing.Size(100, 24);
            this.btn_addMedication.TabIndex = 11;
            this.btn_addMedication.Text = "Add";
            this.btn_addMedication.UseVisualStyleBackColor = true;
            this.btn_addMedication.Click += new System.EventHandler(this.btn_addMedication_Click);
            // 
            // btn_removeMedication
            // 
            this.btn_removeMedication.Location = new System.Drawing.Point(174, 341);
            this.btn_removeMedication.Name = "btn_removeMedication";
            this.btn_removeMedication.Size = new System.Drawing.Size(111, 24);
            this.btn_removeMedication.TabIndex = 12;
            this.btn_removeMedication.Text = "Remove selected";
            this.btn_removeMedication.UseVisualStyleBackColor = true;
            this.btn_removeMedication.Click += new System.EventHandler(this.btn_removeMedication_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(46, 291);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 59;
            this.label18.Text = "Medication";
            // 
            // listBox_visitMedications
            // 
            this.listBox_visitMedications.FormattingEnabled = true;
            this.listBox_visitMedications.Location = new System.Drawing.Point(349, 273);
            this.listBox_visitMedications.Name = "listBox_visitMedications";
            this.listBox_visitMedications.Size = new System.Drawing.Size(296, 134);
            this.listBox_visitMedications.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Notes";
            // 
            // btn_printVisitAction
            // 
            this.btn_printVisitAction.Location = new System.Drawing.Point(571, 28);
            this.btn_printVisitAction.Name = "btn_printVisitAction";
            this.btn_printVisitAction.Size = new System.Drawing.Size(83, 35);
            this.btn_printVisitAction.TabIndex = 15;
            this.btn_printVisitAction.Text = "Print Prescription";
            this.btn_printVisitAction.UseVisualStyleBackColor = true;
            this.btn_printVisitAction.Click += new System.EventHandler(this.btn_printVisitAction_Click);
            // 
            // btn_addVisitAction
            // 
            this.btn_addVisitAction.Location = new System.Drawing.Point(499, 28);
            this.btn_addVisitAction.Name = "btn_addVisitAction";
            this.btn_addVisitAction.Size = new System.Drawing.Size(68, 35);
            this.btn_addVisitAction.TabIndex = 14;
            this.btn_addVisitAction.Text = "Add Visit";
            this.btn_addVisitAction.UseVisualStyleBackColor = true;
            this.btn_addVisitAction.Click += new System.EventHandler(this.btn_addVisitAction_Click);
            // 
            // txt_notes
            // 
            this.txt_notes.Location = new System.Drawing.Point(27, 170);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(280, 72);
            this.txt_notes.TabIndex = 7;
            // 
            // btn_medRefresh
            // 
            this.btn_medRefresh.Location = new System.Drawing.Point(198, 285);
            this.btn_medRefresh.Name = "btn_medRefresh";
            this.btn_medRefresh.Size = new System.Drawing.Size(65, 24);
            this.btn_medRefresh.TabIndex = 10;
            this.btn_medRefresh.Text = "Refresh";
            this.btn_medRefresh.UseVisualStyleBackColor = true;
            this.btn_medRefresh.Click += new System.EventHandler(this.btn_medRefresh_Click);
            // 
            // date_visitDate
            // 
            this.date_visitDate.Location = new System.Drawing.Point(67, 24);
            this.date_visitDate.Name = "date_visitDate";
            this.date_visitDate.Size = new System.Drawing.Size(181, 20);
            this.date_visitDate.TabIndex = 1;
            // 
            // btn_addLabLink
            // 
            this.btn_addLabLink.Location = new System.Drawing.Point(499, 69);
            this.btn_addLabLink.Name = "btn_addLabLink";
            this.btn_addLabLink.Size = new System.Drawing.Size(68, 35);
            this.btn_addLabLink.TabIndex = 16;
            this.btn_addLabLink.Text = "Add new Lab";
            this.btn_addLabLink.UseVisualStyleBackColor = true;
            this.btn_addLabLink.Click += new System.EventHandler(this.btn_addLabLink_Click);
            // 
            // btn_viewLabsLink
            // 
            this.btn_viewLabsLink.Location = new System.Drawing.Point(571, 68);
            this.btn_viewLabsLink.Name = "btn_viewLabsLink";
            this.btn_viewLabsLink.Size = new System.Drawing.Size(83, 35);
            this.btn_viewLabsLink.TabIndex = 17;
            this.btn_viewLabsLink.Text = "View Distinct Labs";
            this.btn_viewLabsLink.UseVisualStyleBackColor = true;
            this.btn_viewLabsLink.Click += new System.EventHandler(this.btn_viewLabsLink_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddNewVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 431);
            this.Controls.Add(this.btn_addLabLink);
            this.Controls.Add(this.btn_viewLabsLink);
            this.Controls.Add(this.date_visitDate);
            this.Controls.Add(this.btn_medRefresh);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.btn_addVisitAction);
            this.Controls.Add(this.btn_printVisitAction);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.combo_medication);
            this.Controls.Add(this.btn_addMedication);
            this.Controls.Add(this.btn_removeMedication);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.listBox_visitMedications);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_tmp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_gasAge);
            this.Controls.Add(this.txt_bl_pr_dom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_weight);
            this.Controls.Add(this.txt_bl_pr_num);
            this.Controls.Add(this.txt_ultraSound);
            this.Name = "AddNewVisit";
            this.Text = "Add New Visit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ultraSound;
        private System.Windows.Forms.TextBox txt_bl_pr_num;
        private System.Windows.Forms.TextBox txt_weight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_bl_pr_dom;
        private System.Windows.Forms.TextBox txt_gasAge;
        private System.Windows.Forms.TextBox txt_tmp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combo_medication;
        private System.Windows.Forms.Button btn_addMedication;
        private System.Windows.Forms.Button btn_removeMedication;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox listBox_visitMedications;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_printVisitAction;
        private System.Windows.Forms.Button btn_addVisitAction;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Button btn_medRefresh;
        private System.Windows.Forms.DateTimePicker date_visitDate;
        private System.Windows.Forms.Button btn_addLabLink;
        private System.Windows.Forms.Button btn_viewLabsLink;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}