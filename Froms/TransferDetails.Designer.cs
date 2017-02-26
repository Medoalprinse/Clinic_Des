namespace Clinic.Froms
{
    partial class TransferDetails
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
            this.txt_patName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_reason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_current = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.btn_printAction = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_fasting = new System.Windows.Forms.ComboBox();
            this.combo_fastingPer = new System.Windows.Forms.ComboBox();
            this.combo_entryPer = new System.Windows.Forms.ComboBox();
            this.combo_entry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_hosName = new System.Windows.Forms.TextBox();
            this.date_transfer = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txt_patName
            // 
            this.txt_patName.Location = new System.Drawing.Point(95, 29);
            this.txt_patName.Name = "txt_patName";
            this.txt_patName.Size = new System.Drawing.Size(199, 20);
            this.txt_patName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transfer \r\nReason";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_reason
            // 
            this.txt_reason.Location = new System.Drawing.Point(94, 135);
            this.txt_reason.Name = "txt_reason";
            this.txt_reason.Size = new System.Drawing.Size(200, 20);
            this.txt_reason.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Operation Date";
            // 
            // date_current
            // 
            this.date_current.Location = new System.Drawing.Point(94, 64);
            this.date_current.Name = "date_current";
            this.date_current.Size = new System.Drawing.Size(200, 20);
            this.date_current.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Age";
            // 
            // txt_age
            // 
            this.txt_age.Location = new System.Drawing.Point(366, 28);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(39, 20);
            this.txt_age.TabIndex = 2;
            // 
            // btn_printAction
            // 
            this.btn_printAction.Location = new System.Drawing.Point(366, 235);
            this.btn_printAction.Name = "btn_printAction";
            this.btn_printAction.Size = new System.Drawing.Size(75, 23);
            this.btn_printAction.TabIndex = 11;
            this.btn_printAction.Text = "Print";
            this.btn_printAction.UseVisualStyleBackColor = true;
            this.btn_printAction.Click += new System.EventHandler(this.btn_printAction_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fasting Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Operation time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // combo_fasting
            // 
            this.combo_fasting.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_fasting.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_fasting.FormattingEnabled = true;
            this.combo_fasting.Items.AddRange(new object[] {
            "12:00",
            "12:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30"});
            this.combo_fasting.Location = new System.Drawing.Point(95, 207);
            this.combo_fasting.Name = "combo_fasting";
            this.combo_fasting.Size = new System.Drawing.Size(108, 21);
            this.combo_fasting.TabIndex = 7;
            // 
            // combo_fastingPer
            // 
            this.combo_fastingPer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_fastingPer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_fastingPer.FormattingEnabled = true;
            this.combo_fastingPer.Items.AddRange(new object[] {
            "A.M.",
            "P.M."});
            this.combo_fastingPer.Location = new System.Drawing.Point(209, 207);
            this.combo_fastingPer.Name = "combo_fastingPer";
            this.combo_fastingPer.Size = new System.Drawing.Size(85, 21);
            this.combo_fastingPer.TabIndex = 8;
            // 
            // combo_entryPer
            // 
            this.combo_entryPer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_entryPer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_entryPer.FormattingEnabled = true;
            this.combo_entryPer.Items.AddRange(new object[] {
            "A.M.",
            "P.M."});
            this.combo_entryPer.Location = new System.Drawing.Point(209, 244);
            this.combo_entryPer.Name = "combo_entryPer";
            this.combo_entryPer.Size = new System.Drawing.Size(85, 21);
            this.combo_entryPer.TabIndex = 10;
            // 
            // combo_entry
            // 
            this.combo_entry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_entry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_entry.FormattingEnabled = true;
            this.combo_entry.Items.AddRange(new object[] {
            "12:00",
            "12:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30"});
            this.combo_entry.Location = new System.Drawing.Point(95, 244);
            this.combo_entry.Name = "combo_entry";
            this.combo_entry.Size = new System.Drawing.Size(108, 21);
            this.combo_entry.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 26);
            this.label8.TabIndex = 19;
            this.label8.Text = "Hospital \r\nName";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_hosName
            // 
            this.txt_hosName.Location = new System.Drawing.Point(94, 99);
            this.txt_hosName.Name = "txt_hosName";
            this.txt_hosName.Size = new System.Drawing.Size(200, 20);
            this.txt_hosName.TabIndex = 4;
            // 
            // date_transfer
            // 
            this.date_transfer.Location = new System.Drawing.Point(95, 170);
            this.date_transfer.Name = "date_transfer";
            this.date_transfer.Size = new System.Drawing.Size(200, 20);
            this.date_transfer.TabIndex = 6;
            // 
            // TransferDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 280);
            this.Controls.Add(this.date_transfer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_hosName);
            this.Controls.Add(this.combo_entryPer);
            this.Controls.Add(this.combo_entry);
            this.Controls.Add(this.combo_fastingPer);
            this.Controls.Add(this.combo_fasting);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_printAction);
            this.Controls.Add(this.txt_age);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date_current);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_reason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_patName);
            this.Name = "TransferDetails";
            this.Text = "Transfer Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_patName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_reason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_current;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.Button btn_printAction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_fasting;
        private System.Windows.Forms.ComboBox combo_fastingPer;
        private System.Windows.Forms.ComboBox combo_entryPer;
        private System.Windows.Forms.ComboBox combo_entry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_hosName;
        private System.Windows.Forms.DateTimePicker date_transfer;
    }
}