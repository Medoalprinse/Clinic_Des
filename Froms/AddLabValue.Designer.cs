namespace Clinic.Froms
{
    partial class AddLabValue
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_addLabValueAction = new System.Windows.Forms.Button();
            this.txt_normalRange = new System.Windows.Forms.TextBox();
            this.txt_labName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lab Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Normal Range";
            // 
            // btn_addLabValueAction
            // 
            this.btn_addLabValueAction.Location = new System.Drawing.Point(96, 152);
            this.btn_addLabValueAction.Name = "btn_addLabValueAction";
            this.btn_addLabValueAction.Size = new System.Drawing.Size(75, 23);
            this.btn_addLabValueAction.TabIndex = 3;
            this.btn_addLabValueAction.Text = "Add Lab";
            this.btn_addLabValueAction.UseVisualStyleBackColor = true;
            this.btn_addLabValueAction.Click += new System.EventHandler(this.btn_addLabValueAction_Click);
            // 
            // txt_normalRange
            // 
            this.txt_normalRange.Location = new System.Drawing.Point(96, 86);
            this.txt_normalRange.Name = "txt_normalRange";
            this.txt_normalRange.Size = new System.Drawing.Size(176, 20);
            this.txt_normalRange.TabIndex = 2;
            // 
            // txt_labName
            // 
            this.txt_labName.Location = new System.Drawing.Point(96, 37);
            this.txt_labName.Name = "txt_labName";
            this.txt_labName.Size = new System.Drawing.Size(176, 20);
            this.txt_labName.TabIndex = 1;
            // 
            // AddLabValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 206);
            this.Controls.Add(this.txt_labName);
            this.Controls.Add(this.txt_normalRange);
            this.Controls.Add(this.btn_addLabValueAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddLabValue";
            this.Text = "AddLabValue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_addLabValueAction;
        private System.Windows.Forms.TextBox txt_normalRange;
        private System.Windows.Forms.TextBox txt_labName;
    }
}