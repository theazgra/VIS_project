namespace WinFormApp.Forms.DialogForms
{
    partial class NewPeriodForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.periodNameTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.seasonTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Uložit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Název měsíčního období";
            // 
            // periodNameTBox
            // 
            this.periodNameTBox.Location = new System.Drawing.Point(181, 65);
            this.periodNameTBox.Name = "periodNameTBox";
            this.periodNameTBox.Size = new System.Drawing.Size(100, 22);
            this.periodNameTBox.TabIndex = 2;
            this.periodNameTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sezóna";
            // 
            // seasonTBox
            // 
            this.seasonTBox.Location = new System.Drawing.Point(181, 31);
            this.seasonTBox.Name = "seasonTBox";
            this.seasonTBox.ReadOnly = true;
            this.seasonTBox.Size = new System.Drawing.Size(100, 22);
            this.seasonTBox.TabIndex = 2;
            this.seasonTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Počáteční datum";
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(181, 98);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(100, 22);
            this.startDate.TabIndex = 3;
            // 
            // NewPeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 214);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.seasonTBox);
            this.Controls.Add(this.periodNameTBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewPeriodForm";
            this.Text = "Nové měsíční období";
            this.Load += new System.EventHandler(this.NewPeriodForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox periodNameTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox seasonTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDate;
    }
}