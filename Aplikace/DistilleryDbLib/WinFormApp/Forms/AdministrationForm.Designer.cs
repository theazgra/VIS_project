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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            // 
            // actualPeriodTBox
            // 
            this.actualPeriodTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.actualPeriodTBox.Location = new System.Drawing.Point(249, 107);
            this.actualPeriodTBox.Name = "actualPeriodTBox";
            this.actualPeriodTBox.ReadOnly = true;
            this.actualPeriodTBox.Size = new System.Drawing.Size(120, 26);
            this.actualPeriodTBox.TabIndex = 1;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ukončit aktuální měsíční období";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseMonthPeriod);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Vytvořit nové měsíční období";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NewMonthPeriod);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 258);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 39);
            this.button3.TabIndex = 4;
            this.button3.Text = "Vytvořit novou sezónu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(431, 335);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}