namespace WinFormApp.Forms
{
    partial class CustomerDetail
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
            this.cityCB = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.streetTBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.houseNumTBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.emailTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.perNumTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.surenameTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.regDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.distilledVolumeTBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.reservationPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.customerReservationList = new System.Windows.Forms.DataGridView();
            this.custId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerReservationList)).BeginInit();
            this.SuspendLayout();
            // 
            // cityCB
            // 
            this.cityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityCB.FormattingEnabled = true;
            this.cityCB.Location = new System.Drawing.Point(153, 220);
            this.cityCB.Name = "cityCB";
            this.cityCB.Size = new System.Drawing.Size(136, 24);
            this.cityCB.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Město";
            // 
            // streetTBox
            // 
            this.streetTBox.Location = new System.Drawing.Point(153, 189);
            this.streetTBox.Name = "streetTBox";
            this.streetTBox.Size = new System.Drawing.Size(136, 22);
            this.streetTBox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ulice";
            // 
            // houseNumTBox
            // 
            this.houseNumTBox.Location = new System.Drawing.Point(153, 161);
            this.houseNumTBox.Name = "houseNumTBox";
            this.houseNumTBox.Size = new System.Drawing.Size(136, 22);
            this.houseNumTBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Číslo domu";
            // 
            // emailTBox
            // 
            this.emailTBox.Location = new System.Drawing.Point(153, 133);
            this.emailTBox.Name = "emailTBox";
            this.emailTBox.Size = new System.Drawing.Size(136, 22);
            this.emailTBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // phoneTBox
            // 
            this.phoneTBox.Location = new System.Drawing.Point(153, 105);
            this.phoneTBox.Name = "phoneTBox";
            this.phoneTBox.Size = new System.Drawing.Size(136, 22);
            this.phoneTBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Telefon";
            // 
            // perNumTBox
            // 
            this.perNumTBox.Location = new System.Drawing.Point(153, 77);
            this.perNumTBox.Name = "perNumTBox";
            this.perNumTBox.Size = new System.Drawing.Size(136, 22);
            this.perNumTBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rodné číslo";
            // 
            // surenameTBox
            // 
            this.surenameTBox.Location = new System.Drawing.Point(153, 49);
            this.surenameTBox.Name = "surenameTBox";
            this.surenameTBox.Size = new System.Drawing.Size(136, 22);
            this.surenameTBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Příjmení";
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(153, 21);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(136, 22);
            this.nameTBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Jméno";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Datum registrace";
            // 
            // regDate
            // 
            this.regDate.Location = new System.Drawing.Point(153, 250);
            this.regDate.Name = "regDate";
            this.regDate.ReadOnly = true;
            this.regDate.Size = new System.Drawing.Size(136, 22);
            this.regDate.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Vypálené množství";
            // 
            // distilledVolumeTBox
            // 
            this.distilledVolumeTBox.Location = new System.Drawing.Point(153, 278);
            this.distilledVolumeTBox.Name = "distilledVolumeTBox";
            this.distilledVolumeTBox.ReadOnly = true;
            this.distilledVolumeTBox.Size = new System.Drawing.Size(136, 22);
            this.distilledVolumeTBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 52);
            this.button1.TabIndex = 10;
            this.button1.Text = "Uložit změny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveCustomerClick);
            // 
            // reservationPanel
            // 
            this.reservationPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.reservationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reservationPanel.Controls.Add(this.customerReservationList);
            this.reservationPanel.Location = new System.Drawing.Point(330, 52);
            this.reservationPanel.Name = "reservationPanel";
            this.reservationPanel.Size = new System.Drawing.Size(624, 336);
            this.reservationPanel.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(327, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Rezervace zákazníka";
            // 
            // customerReservationList
            // 
            this.customerReservationList.AllowUserToAddRows = false;
            this.customerReservationList.AllowUserToDeleteRows = false;
            this.customerReservationList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerReservationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerReservationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.custId,
            this.customer,
            this.idcol,
            this.matId,
            this.reqDate,
            this.MaterialCol,
            this.matAmount,
            this.resDate});
            this.customerReservationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerReservationList.Location = new System.Drawing.Point(0, 0);
            this.customerReservationList.MultiSelect = false;
            this.customerReservationList.Name = "customerReservationList";
            this.customerReservationList.ReadOnly = true;
            this.customerReservationList.RowTemplate.Height = 24;
            this.customerReservationList.Size = new System.Drawing.Size(622, 334);
            this.customerReservationList.TabIndex = 0;
            // 
            // custId
            // 
            this.custId.DataPropertyName = "Customer_Id";
            this.custId.HeaderText = "Column1";
            this.custId.Name = "custId";
            this.custId.ReadOnly = true;
            this.custId.Visible = false;
            // 
            // customer
            // 
            this.customer.DataPropertyName = "Customer";
            this.customer.HeaderText = "Column1";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            this.customer.Visible = false;
            // 
            // idcol
            // 
            this.idcol.DataPropertyName = "Id";
            this.idcol.HeaderText = "Column1";
            this.idcol.Name = "idcol";
            this.idcol.ReadOnly = true;
            this.idcol.Visible = false;
            // 
            // matId
            // 
            this.matId.DataPropertyName = "Material_Id";
            this.matId.HeaderText = "Column1";
            this.matId.Name = "matId";
            this.matId.ReadOnly = true;
            this.matId.Visible = false;
            // 
            // reqDate
            // 
            this.reqDate.DataPropertyName = "RequestedDateTime";
            this.reqDate.HeaderText = "Požadované datum a čas";
            this.reqDate.Name = "reqDate";
            this.reqDate.ReadOnly = true;
            // 
            // MaterialCol
            // 
            this.MaterialCol.DataPropertyName = "Material";
            this.MaterialCol.HeaderText = "Materiál";
            this.MaterialCol.Name = "MaterialCol";
            this.MaterialCol.ReadOnly = true;
            // 
            // matAmount
            // 
            this.matAmount.DataPropertyName = "MaterialAmount";
            this.matAmount.HeaderText = "Množství materiálu";
            this.matAmount.Name = "matAmount";
            this.matAmount.ReadOnly = true;
            // 
            // resDate
            // 
            this.resDate.DataPropertyName = "ReservationDateTime";
            this.resDate.HeaderText = "Datum rezervace";
            this.resDate.Name = "resDate";
            this.resDate.ReadOnly = true;
            // 
            // CustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 400);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.reservationPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cityCB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.distilledVolumeTBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.regDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.streetTBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.houseNumTBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.emailTBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phoneTBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.perNumTBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.surenameTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label1);
            this.Name = "CustomerDetail";
            this.Text = "Detail zákazníka";
            this.Load += new System.EventHandler(this.CustomerDetail_Load);
            this.reservationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerReservationList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cityCB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox streetTBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox houseNumTBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emailTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phoneTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox perNumTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox surenameTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox regDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox distilledVolumeTBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel reservationPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView customerReservationList;
        private System.Windows.Forms.DataGridViewTextBoxColumn custId;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn matId;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn matAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn resDate;
    }
}