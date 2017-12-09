namespace WinFormApp.Forms
{
    partial class AdministrationForm
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
            this.actualSeasonTBox = new System.Windows.Forms.TextBox();
            this.actualPeriodTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEndPeriod = new System.Windows.Forms.Button();
            this.btnStartPeriod = new System.Windows.Forms.Button();
            this.btnStartSeason = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(25, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktuální sezóna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(25, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aktuální měsíční období";
            // 
            // actualSeasonTBox
            // 
            this.actualSeasonTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.actualSeasonTBox.Location = new System.Drawing.Point(249, 61);
            this.actualSeasonTBox.Name = "actualSeasonTBox";
            this.actualSeasonTBox.ReadOnly = true;
            this.actualSeasonTBox.Size = new System.Drawing.Size(120, 26);
            this.actualSeasonTBox.TabIndex = 0;
            this.actualSeasonTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // actualPeriodTBox
            // 
            this.actualPeriodTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.actualPeriodTBox.Location = new System.Drawing.Point(249, 107);
            this.actualPeriodTBox.Name = "actualPeriodTBox";
            this.actualPeriodTBox.ReadOnly = true;
            this.actualPeriodTBox.Size = new System.Drawing.Size(120, 26);
            this.actualPeriodTBox.TabIndex = 1;
            this.actualPeriodTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(80, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Administrace pěstitelské pálenice";
            // 
            // btnEndPeriod
            // 
            this.btnEndPeriod.Location = new System.Drawing.Point(100, 213);
            this.btnEndPeriod.Name = "btnEndPeriod";
            this.btnEndPeriod.Size = new System.Drawing.Size(224, 39);
            this.btnEndPeriod.TabIndex = 2;
            this.btnEndPeriod.Text = "Ukončit aktuální měsíční období";
            this.btnEndPeriod.UseVisualStyleBackColor = true;
            this.btnEndPeriod.Click += new System.EventHandler(this.CloseMonthPeriod);
            // 
            // btnStartPeriod
            // 
            this.btnStartPeriod.Location = new System.Drawing.Point(100, 303);
            this.btnStartPeriod.Name = "btnStartPeriod";
            this.btnStartPeriod.Size = new System.Drawing.Size(224, 39);
            this.btnStartPeriod.TabIndex = 3;
            this.btnStartPeriod.Text = "Vytvořit nové měsíční období";
            this.btnStartPeriod.UseVisualStyleBackColor = true;
            this.btnStartPeriod.Click += new System.EventHandler(this.NewMonthPeriod);
            // 
            // btnStartSeason
            // 
            this.btnStartSeason.Location = new System.Drawing.Point(100, 258);
            this.btnStartSeason.Name = "btnStartSeason";
            this.btnStartSeason.Size = new System.Drawing.Size(224, 39);
            this.btnStartSeason.TabIndex = 4;
            this.btnStartSeason.Text = "Vytvořit novou sezónu";
            this.btnStartSeason.UseVisualStyleBackColor = true;
            this.btnStartSeason.Click += new System.EventHandler(this.NewSeason);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(431, 356);
            this.Controls.Add(this.btnStartSeason);
            this.Controls.Add(this.btnStartPeriod);
            this.Controls.Add(this.btnEndPeriod);
            this.Controls.Add(this.actualPeriodTBox);
            this.Controls.Add(this.actualSeasonTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AdministrationForm";
            this.Text = " Administrace Palenice";
            this.Load += new System.EventHandler(this.AdministrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox actualSeasonTBox;
        private System.Windows.Forms.TextBox actualPeriodTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEndPeriod;
        private System.Windows.Forms.Button btnStartPeriod;
        private System.Windows.Forms.Button btnStartSeason;
    }
}