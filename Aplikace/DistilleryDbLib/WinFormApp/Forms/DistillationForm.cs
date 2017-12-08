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
    public partial class DistillationForm : Form
    {
        //private List<Distillation> _distillationList;
        public DistillationForm()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            //_distillationList = DistillationTable.Select().ToList();
            //distillationGridView.DataSource = _distillationList;
        }

        private void DistillationForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void detailPáleníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////Distillation d = distillationGridView.CurrentRow.DataBoundItem as Distillation;
            //if (d != null)
            //{
            //    DistillationDetail dd = new DistillationDetail(d.Id);
            //    if (dd.ShowDialog() == DialogResult.OK)
            //    {
            //        Reload();
            //    }
            //}
        }

        private void distillationGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ////Distillation d = distillationGridView.CurrentRow.DataBoundItem as Distillation;
            //if (d != null)
            //{
            //    DistillationDetail dd = new DistillationDetail(d.Id);
            //    if (dd.ShowDialog() == DialogResult.OK)
            //    {
            //        Reload();
            //    }
            //}
        }
    }
}
