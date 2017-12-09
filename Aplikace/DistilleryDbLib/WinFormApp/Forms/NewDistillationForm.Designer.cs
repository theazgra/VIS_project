namespace WinFormApp.Forms
{
    partial class NewDistillationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDistillationForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialCB = new System.Windows.Forms.ComboBox();
            this.chBPayed = new System.Windows.Forms.CheckBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbLAA = new System.Windows.Forms.TextBox();
            this.tbDistVolume = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbPercAlc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPeriod = new System.Windows.Forms.TextBox();
            this.tbSeason = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbLaaLimit = new System.Windows.Forms.TextBox();
            this.tbSurename = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.miSelectCustomer = new System.Windows.Forms.ToolStripButton();
            this.miCreateCust = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.materialCB);
            this.panel2.Controls.Add(this.chBPayed);
            this.panel2.Controls.Add(this.tbPrice);
            this.panel2.Controls.Add(this.tbLAA);
            this.panel2.Controls.Add(this.tbDistVolume);
            this.panel2.Controls.Add(this.tbAmount);
            this.panel2.Controls.Add(this.tbPercAlc);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 222);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 246);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // materialCB
            // 
            this.materialCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialCB.FormattingEnabled = true;
            this.materialCB.Location = new System.Drawing.Point(279, 19);
            this.materialCB.Name = "materialCB";
            this.materialCB.Size = new System.Drawing.Size(128, 24);
            this.materialCB.TabIndex = 0;
            this.materialCB.SelectedIndexChanged += new System.EventHandler(this.materialCB_SelectedIndexChanged);
            // 
            // chBPayed
            // 
            this.chBPayed.AutoSize = true;
            this.chBPayed.Location = new System.Drawing.Point(423, 192);
            this.chBPayed.Name = "chBPayed";
            this.chBPayed.Size = new System.Drawing.Size(97, 21);
            this.chBPayed.TabIndex = 6;
            this.chBPayed.Text = "Zaplaceno";
            this.chBPayed.UseVisualStyleBackColor = true;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(279, 193);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(128, 22);
            this.tbPrice.TabIndex = 5;
            // 
            // tbLAA
            // 
            this.tbLAA.Location = new System.Drawing.Point(279, 133);
            this.tbLAA.Name = "tbLAA";
            this.tbLAA.ReadOnly = true;
            this.tbLAA.Size = new System.Drawing.Size(128, 22);
            this.tbLAA.TabIndex = 4;
            // 
            // tbDistVolume
            // 
            this.tbDistVolume.Location = new System.Drawing.Point(279, 77);
            this.tbDistVolume.Name = "tbDistVolume";
            this.tbDistVolume.Size = new System.Drawing.Size(128, 22);
            this.tbDistVolume.TabIndex = 2;
            this.tbDistVolume.TextChanged += new System.EventHandler(this.CalcLaa);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(279, 49);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(128, 22);
            this.tbAmount.TabIndex = 1;
            // 
            // tbPercAlc
            // 
            this.tbPercAlc.Location = new System.Drawing.Point(279, 105);
            this.tbPercAlc.Name = "tbPercAlc";
            this.tbPercAlc.Size = new System.Drawing.Size(43, 22);
            this.tbPercAlc.TabIndex = 3;
            this.tbPercAlc.TextChanged += new System.EventHandler(this.CalcLaa);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Vypálené množství (litrů)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Materiál";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 196);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Cena (Kč)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 108);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(159, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Při obsahu alkoholu (%)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "L.A.A.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Množství materiálu (Kg)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(671, 45);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Období";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(671, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Sezóna";
            // 
            // tbPeriod
            // 
            this.tbPeriod.Location = new System.Drawing.Point(734, 42);
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.ReadOnly = true;
            this.tbPeriod.Size = new System.Drawing.Size(128, 22);
            this.tbPeriod.TabIndex = 2;
            // 
            // tbSeason
            // 
            this.tbSeason.Location = new System.Drawing.Point(734, 10);
            this.tbSeason.Name = "tbSeason";
            this.tbSeason.ReadOnly = true;
            this.tbSeason.Size = new System.Drawing.Size(128, 22);
            this.tbSeason.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbLaaLimit);
            this.panel1.Controls.Add(this.tbSurename);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbPeriod);
            this.panel1.Controls.Add(this.tbSeason);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 127);
            this.panel1.TabIndex = 4;
            // 
            // tbLaaLimit
            // 
            this.tbLaaLimit.Location = new System.Drawing.Point(279, 95);
            this.tbLaaLimit.Name = "tbLaaLimit";
            this.tbLaaLimit.ReadOnly = true;
            this.tbLaaLimit.Size = new System.Drawing.Size(128, 22);
            this.tbLaaLimit.TabIndex = 2;
            // 
            // tbSurename
            // 
            this.tbSurename.Location = new System.Drawing.Point(279, 67);
            this.tbSurename.Name = "tbSurename";
            this.tbSurename.ReadOnly = true;
            this.tbSurename.Size = new System.Drawing.Size(128, 22);
            this.tbSurename.TabIndex = 2;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(279, 39);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(128, 22);
            this.tbName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ještě může vypálit [L.A.A.]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Příjmení";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jméno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zákazník";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 31);
            this.panel3.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(710, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Uložit pálení";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveDist);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSelectCustomer,
            this.miCreateCust});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(874, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // miSelectCustomer
            // 
            this.miSelectCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miSelectCustomer.Image = ((System.Drawing.Image)(resources.GetObject("miSelectCustomer.Image")));
            this.miSelectCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miSelectCustomer.Name = "miSelectCustomer";
            this.miSelectCustomer.Size = new System.Drawing.Size(124, 28);
            this.miSelectCustomer.Text = "Vybrat zákazníka";
            this.miSelectCustomer.Click += new System.EventHandler(this.SelectCustClick);
            // 
            // miCreateCust
            // 
            this.miCreateCust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miCreateCust.Image = ((System.Drawing.Image)(resources.GetObject("miCreateCust.Image")));
            this.miCreateCust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miCreateCust.Name = "miCreateCust";
            this.miCreateCust.Size = new System.Drawing.Size(132, 28);
            this.miCreateCust.Text = "Vytvořit zákazníka";
            this.miCreateCust.Click += new System.EventHandler(this.CreateCust);
            // 
            // NewDistillationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "NewDistillationForm";
            this.Text = "Nový záznam pálení";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox materialCB;
        private System.Windows.Forms.CheckBox chBPayed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbLAA;
        private System.Windows.Forms.TextBox tbDistVolume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbPercAlc;
        private System.Windows.Forms.TextBox tbPeriod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSeason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbLaaLimit;
        private System.Windows.Forms.TextBox tbSurename;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton miSelectCustomer;
        private System.Windows.Forms.ToolStripButton miCreateCust;
    }
}