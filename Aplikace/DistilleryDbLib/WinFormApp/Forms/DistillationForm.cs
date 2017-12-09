using System;
using DistilleryLogic;
using System.Windows.Forms;
using DataLayerNetCore.Entities;
using System.Collections.Generic;

namespace WinFormApp.Forms
{
    public partial class DistillationForm : Form
    {
        private ICollection<Distillation> _distillationList;
        public DistillationForm()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            _distillationList = DistillationLogic.GetAllDistilations();
            distillationGridView.DataSource = _distillationList;
        }

        private void DistillationForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void detailPáleníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (distillationGridView.CurrentRow.DataBoundItem is Distillation distillation)
            {
                DistillationDetail dd = new DistillationDetail(distillation.Id);
                if (dd.ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
            }
        }

        private void distillationGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (distillationGridView.CurrentRow.DataBoundItem is Distillation distillation)
            {
                DistillationDetail dd = new DistillationDetail(distillation.Id);
                if (dd.ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
            }
        }
    }
}
