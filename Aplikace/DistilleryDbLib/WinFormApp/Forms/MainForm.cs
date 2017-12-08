﻿using System;
using DataLayerNetCore.Entities;
using System.Windows.Forms;

namespace WinFormApp.Forms
{
    public partial class MainForm : Form
    {
        private UserInfo _loggedUser;

        public MainForm(UserInfo user)
        {
            if (user == null)
                Close();

            _loggedUser = user;
            InitializeComponent();
        }

        private void CustomersMIClick(object sender, EventArgs e)
        {
            AddMdiChild(new CustomerForm());
        }

        private void AddMdiChild(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void administraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrationForm af = new AdministrationForm();
            AddMdiChild(af);
        }

        private void DistillationListClick(object sender, EventArgs e)
        {
            DistillationForm df = new DistillationForm();
            AddMdiChild(df);
        }

        private void closeMdiChildsMI_Click(object sender, EventArgs e)
        {
            foreach (Form mdiChild in MdiChildren)
            {
                mdiChild.Close();
            }
        }
    }
}
