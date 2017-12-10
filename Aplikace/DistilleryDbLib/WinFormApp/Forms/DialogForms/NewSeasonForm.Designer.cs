namespace WinFormApp.Forms.DialogForms
{
    partial class NewSeasonForm
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
            this.tbStartDate = new System.Windows.Forms.DateTimePicker();
            this.tbSeason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbStartDate
            // 
            this.tbStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbStartDate.Location = new System.Drawing.Point(156, 70);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(114, 22);
            this.tbStartDate.TabIndex = 8;
            // 
            // tbSeason
            // 
            this.tbSeason.Location = new System.Drawing.Point(156, 33);
            this.tbSeason.Name = "tbSeason";
            this.tbSeason.Size = new System.Drawing.Size(114, 22);
            this.tbSeason.TabIndex = 7;
            this.tbSeason.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Počáteční datum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Název sezóny";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(91, 119);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(91, 41);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Uložit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.Save);
            // 
            // NewSeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 177);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.tbSeason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewSeasonForm";
            this.Text = "Nová sezóna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker tbStartDate;
        private System.Windows.Forms.TextBox tbSeason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
    }
}