using System;
using DataLayerNetCore.Entities;
using System.Windows.Forms;
using WinFormApp.Forms.DialogForms;
using DistilleryLogic;

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

        private void NewDistClick(object sender, EventArgs e)
        {
            if (AdministrationLogic.GetActivePeriod() != null && AdministrationLogic.GetActiveSeason() != null)
            {
                NewDistillationForm ndf = new NewDistillationForm();
                AddMdiChild(ndf);
            }
            else
            {
                MessageBox.Show("Není nastavená sezóna nebo měsíční období přejděte do administrace.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
