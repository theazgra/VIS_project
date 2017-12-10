namespace WinFormApp.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novýZáznamPáleníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přehledPáleníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zákaznícíToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.číselníkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.číselníkMěstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.číselníkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.číselníkKrajůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.číselníkMateriálůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.oknaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMdiChildsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novýZáznamPáleníToolStripMenuItem,
            this.přehledPáleníToolStripMenuItem,
            this.zákaznícíToolStripMenuItem,
            this.číselníkyToolStripMenuItem,
            this.miAdmin,
            this.oknaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novýZáznamPáleníToolStripMenuItem
            // 
            this.novýZáznamPáleníToolStripMenuItem.Name = "novýZáznamPáleníToolStripMenuItem";
            this.novýZáznamPáleníToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.novýZáznamPáleníToolStripMenuItem.Text = "Nový záznam pálení";
            this.novýZáznamPáleníToolStripMenuItem.Click += new System.EventHandler(this.NewDistClick);
            // 
            // přehledPáleníToolStripMenuItem
            // 
            this.přehledPáleníToolStripMenuItem.Name = "přehledPáleníToolStripMenuItem";
            this.přehledPáleníToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.přehledPáleníToolStripMenuItem.Text = "Přehled pálení";
            this.přehledPáleníToolStripMenuItem.Click += new System.EventHandler(this.DistillationListClick);
            // 
            // zákaznícíToolStripMenuItem
            // 
            this.zákaznícíToolStripMenuItem.Name = "zákaznícíToolStripMenuItem";
            this.zákaznícíToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.zákaznícíToolStripMenuItem.Text = "Zákaznící";
            this.zákaznícíToolStripMenuItem.Click += new System.EventHandler(this.CustomersMIClick);
            // 
            // číselníkyToolStripMenuItem
            // 
            this.číselníkyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.číselníkMěstToolStripMenuItem,
            this.číselníkToolStripMenuItem,
            this.číselníkKrajůToolStripMenuItem,
            this.číselníkMateriálůToolStripMenuItem});
            this.číselníkyToolStripMenuItem.Name = "číselníkyToolStripMenuItem";
            this.číselníkyToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.číselníkyToolStripMenuItem.Text = "Číselníky";
            // 
            // číselníkMěstToolStripMenuItem
            // 
            this.číselníkMěstToolStripMenuItem.Name = "číselníkMěstToolStripMenuItem";
            this.číselníkMěstToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.číselníkMěstToolStripMenuItem.Text = "Číselník měst";
            // 
            // číselníkToolStripMenuItem
            // 
            this.číselníkToolStripMenuItem.Name = "číselníkToolStripMenuItem";
            this.číselníkToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.číselníkToolStripMenuItem.Text = "Číselník okresů";
            // 
            // číselníkKrajůToolStripMenuItem
            // 
            this.číselníkKrajůToolStripMenuItem.Name = "číselníkKrajůToolStripMenuItem";
            this.číselníkKrajůToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.číselníkKrajůToolStripMenuItem.Text = "Číselník krajů";
            // 
            // číselníkMateriálůToolStripMenuItem
            // 
            this.číselníkMateriálůToolStripMenuItem.Name = "číselníkMateriálůToolStripMenuItem";
            this.číselníkMateriálůToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.číselníkMateriálůToolStripMenuItem.Text = "Číselník materiálů";
            // 
            // miAdmin
            // 
            this.miAdmin.Name = "miAdmin";
            this.miAdmin.Size = new System.Drawing.Size(108, 24);
            this.miAdmin.Text = "Administrace";
            this.miAdmin.Click += new System.EventHandler(this.administraceToolStripMenuItem_Click);
            // 
            // oknaToolStripMenuItem
            // 
            this.oknaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeMdiChildsMI});
            this.oknaToolStripMenuItem.Name = "oknaToolStripMenuItem";
            this.oknaToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.oknaToolStripMenuItem.Text = "Okna";
            // 
            // closeMdiChildsMI
            // 
            this.closeMdiChildsMI.Name = "closeMdiChildsMI";
            this.closeMdiChildsMI.Size = new System.Drawing.Size(147, 26);
            this.closeMdiChildsMI.Text = "Zavřít vše";
            this.closeMdiChildsMI.Click += new System.EventHandler(this.closeMdiChildsMI_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 641);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Pěstitelská pálenice";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zákaznícíToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novýZáznamPáleníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přehledPáleníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem číselníkyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAdmin;
        private System.Windows.Forms.ToolStripMenuItem číselníkMěstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem číselníkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem číselníkKrajůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem číselníkMateriálůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oknaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMdiChildsMI;
    }
}

