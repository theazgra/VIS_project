using System;
using DistilleryLogic;
using DataLayerNetCore.Entities;
using System.Windows.Forms;

namespace WinFormApp.Forms.DialogForms
{
    public partial class NewPeriodForm : Form
    {
        public Period NewPeriod { get; private set; }
        public NewPeriodForm()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(periodNameTBox.Text))
            {
                MessageBox.Show("Není vypněno jméno období!", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Period p = new Period
            {
                Name = periodNameTBox.Text,
                StartDate = startDate.Value,
                EndDate = null,
                Finished = false,
                Season = AdministrationLogic.GetActiveSeason(),
                Season_Id = AdministrationLogic.GetActiveSeason().Id
            };

            NewPeriod = p;

            DialogResult = DialogResult.OK;
        }

        private void NewPeriodForm_Load(object sender, EventArgs e)
        {
            seasonTBox.Text = AdministrationLogic.GetActiveSeason().Name;
            startDate.Value = DateTime.Today;
        }
    }
}
