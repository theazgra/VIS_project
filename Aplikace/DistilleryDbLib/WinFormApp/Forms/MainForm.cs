using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void customerToolTipMenuItemClick(object sender, EventArgs e)
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
