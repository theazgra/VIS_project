using System;
using System.Windows.Forms;
using DataLayerNetCore.Entities;

namespace WinFormApp.Forms.DialogForms
{
    public partial class NewSeasonForm : Form
    {
        public Season NewSeason { get; private set; }
        public NewSeasonForm()
        {
            InitializeComponent();
            int year = DateTime.Today.Year;

            tbStartDate.Value = DateTime.Today;
            tbSeason.Text = year.ToString() + "/" + (year + 1).ToString();
        }

        private void Save(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSeason.Text))
            {
                MessageBox.Show("Není vyplněn název sezóny.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Season newSeason = new Season
            {
                Name = tbSeason.Text,
                StartDate = tbStartDate.Value
            };

            NewSeason = newSeason;
            DialogResult = DialogResult.OK;
        }
    }
}
