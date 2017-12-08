using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp.Forms.DialogForms
{
    public partial class NewPeriodForm : Form
    {
        public NewPeriodForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(periodNameTBox.Text))
            //{
            //    MessageBox.Show("Není vypněno jméno období!", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //Period p = new Period
            //{
            //    name = periodNameTBox.Text,
            //    startDate = startDate.Value,
            //    endDate = null,
            //    finished = false,
            //    Season_Id = SeasonTable.Select().Where(s => s.finished == false).FirstOrDefault().Id
            //};
            //try
            //{
            //    PeriodTable.Insert(p);
            //    DialogResult = DialogResult.OK;
            //}
            //catch (DatabaseException)
            //{
            //    DialogResult = DialogResult.Cancel;
            //    MessageBox.Show("Nepodarilo se vlozit obdobi!", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void NewPeriodForm_Load(object sender, EventArgs e)
        {
            //seasonTBox.Text = SeasonTable.ActiveSeasonName();
            startDate.Value = DateTime.Today;
        }
    }
}
