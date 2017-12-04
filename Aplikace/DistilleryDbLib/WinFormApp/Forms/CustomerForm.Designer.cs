namespace WinFormApp.Forms
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityIdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surenameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distilledCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streetCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.houseNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addCustomer = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.searchTBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerGridView
            // 
            this.customerGridView.AllowUserToAddRows = false;
            this.customerGridView.AllowUserToDeleteRows = false;
            this.customerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.cityIdCol,
            this.cityCol,
            this.nameCol,
            this.surenameCol,
            this.perNumCol,
            this.phoneCol,
            this.emailCol,
            this.distilledCol,
            this.regDateCol,
            this.noteCol,
            this.streetCol,
            this.houseNumCol});
            this.customerGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customerGridView.Location = new System.Drawing.Point(0, 181);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.RowTemplate.Height = 24;
            this.customerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGridView.Size = new System.Drawing.Size(929, 389);
            this.customerGridView.TabIndex = 0;
            this.customerGridView.DoubleClick += new System.EventHandler(this.customerGridView_DoubleClick);
            // 
            // idCol
            // 
            this.idCol.DataPropertyName = "Id";
            this.idCol.HeaderText = "Id";
            this.idCol.Name = "idCol";
            this.idCol.ReadOnly = true;
            this.idCol.Visible = false;
            // 
            // cityIdCol
            // 
            this.cityIdCol.DataPropertyName = "city_id";
            this.cityIdCol.HeaderText = "cityId";
            this.cityIdCol.Name = "cityIdCol";
            this.cityIdCol.ReadOnly = true;
            this.cityIdCol.Visible = false;
            // 
            // cityCol
            // 
            this.cityCol.DataPropertyName = "City";
            this.cityCol.HeaderText = "City";
            this.cityCol.Name = "cityCol";
            this.cityCol.ReadOnly = true;
            this.cityCol.Visible = false;
            // 
            // nameCol
            // 
            this.nameCol.DataPropertyName = "name";
            this.nameCol.HeaderText = "Jméno";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // surenameCol
            // 
            this.surenameCol.DataPropertyName = "surename";
            this.surenameCol.HeaderText = "Příjmení";
            this.surenameCol.Name = "surenameCol";
            this.surenameCol.ReadOnly = true;
            // 
            // perNumCol
            // 
            this.perNumCol.DataPropertyName = "personalNumber";
            this.perNumCol.HeaderText = "Rodné číslo";
            this.perNumCol.Name = "perNumCol";
            this.perNumCol.ReadOnly = true;
            // 
            // phoneCol
            // 
            this.phoneCol.DataPropertyName = "phone";
            this.phoneCol.HeaderText = "Telefon";
            this.phoneCol.Name = "phoneCol";
            this.phoneCol.ReadOnly = true;
            // 
            // emailCol
            // 
            this.emailCol.DataPropertyName = "email";
            this.emailCol.HeaderText = "Email";
            this.emailCol.Name = "emailCol";
            this.emailCol.ReadOnly = true;
            // 
            // distilledCol
            // 
            this.distilledCol.DataPropertyName = "distilledVolume";
            this.distilledCol.HeaderText = "Vypáleno (litrů)";
            this.distilledCol.Name = "distilledCol";
            this.distilledCol.ReadOnly = true;
            // 
            // regDateCol
            // 
            this.regDateCol.DataPropertyName = "registrationDate";
            this.regDateCol.HeaderText = "Registrace";
            this.regDateCol.Name = "regDateCol";
            this.regDateCol.ReadOnly = true;
            this.regDateCol.Visible = false;
            // 
            // noteCol
            // 
            this.noteCol.DataPropertyName = "note";
            this.noteCol.HeaderText = "note";
            this.noteCol.Name = "noteCol";
            this.noteCol.ReadOnly = true;
            this.noteCol.Visible = false;
            // 
            // streetCol
            // 
            this.streetCol.DataPropertyName = "street";
            this.streetCol.HeaderText = "Ulice";
            this.streetCol.Name = "streetCol";
            this.streetCol.ReadOnly = true;
            // 
            // houseNumCol
            // 
            this.houseNumCol.DataPropertyName = "houseNumber";
            this.houseNumCol.HeaderText = "Číslo domu";
            this.houseNumCol.Name = "houseNumCol";
            this.houseNumCol.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomer,
            this.deleteBtn,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.searchTBox,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(929, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addCustomer
            // 
            this.addCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCustomer.Image = ((System.Drawing.Image)(resources.GetObject("addCustomer.Image")));
            this.addCustomer.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.addCustomer.Name = "addCustomer";
            this.addCustomer.Size = new System.Drawing.Size(24, 24);
            this.addCustomer.Text = "toolStripButton1";
            this.addCustomer.ToolTipText = "Přidat zákazníka";
            this.addCustomer.Click += new System.EventHandler(this.addCustomer_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(24, 24);
            this.deleteBtn.Text = "toolStripButton1";
            this.deleteBtn.ToolTipText = "Odstranit zákazníka";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(191, 24);
            this.toolStripLabel1.Text = "Vyhledávání podle příjmení";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // searchTBox
            // 
            this.searchTBox.Name = "searchTBox";
            this.searchTBox.Size = new System.Drawing.Size(100, 27);
            this.searchTBox.TextChanged += new System.EventHandler(this.searchTBox_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.SystemColors.Window;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Reload";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 570);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.customerGridView);
            this.Name = "CustomerForm";
            this.Text = "Zákaznící";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityIdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn surenameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn perNumCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn distilledCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn regDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn streetCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn houseNumCol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox searchTBox;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}