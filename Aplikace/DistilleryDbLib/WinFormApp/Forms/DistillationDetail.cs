using DistilleryDbLib;
using DistilleryDbLib.Adapters;
using DistilleryDbLib.Classes;
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
    public partial class DistillationDetail : Form
    {
        private Distillation _distillation;
        public DistillationDetail(int distillationId)
        {
            InitializeComponent();
            _distillation = DistillationTable.Select(distillationId);
        }

        private void DistillationDetail_Load(object sender, EventArgs e)
        {
            materialCB.DataSource = MaterialTable.Select().ToList();
            materialCB.DisplayMember = "name";
            foreach (Material item in materialCB.Items)
            {
                if (item.Id == _distillation.Material_Id)
                {
                    materialCB.SelectedItem = item;
                    break;
                }
            }

            infoLabel.Text = string.Format("Páleni ze dne {0} - {1}", _distillation.date.ToShortDateString(), _distillation.Customer.surename);
            nameTBox.Text = _distillation.Customer.name;
            surenameTBox.Text = _distillation.Customer.surename;
            adressTbox1.Text = _distillation.Customer.houseNumber + " " + _distillation.Customer.street;
            adressTBox2.Text = _distillation.Customer.City.nameZip;

            timeTBox.Text = _distillation.endTime.Subtract(_distillation.startTime).ToString();

            amountTBox.Text = _distillation.amount.ToString("0.00");
            percTBox.Text = _distillation.ethanolPercentage.ToString("0.00");
            distilledVolumeTBox.Text = _distillation.distilledVolume.ToString("0.00");
            laaTBox.Text = _distillation.absoluteAlcoholVolume.ToString("0.00");
            priceTBox.Text = _distillation.price.ToString("0.00");
            payedCB.Checked = _distillation.payed;

            seasonTBox.Text = _distillation.Season.name;
            periodTBox.Text = _distillation.Period.name;

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void custDetailBtn_Click(object sender, EventArgs e)
        {
            CustomerDetail cd = new CustomerDetail(_distillation.Id);
            cd.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int i = DistillationTable.Delete(_distillation.Id);
            if ( i <= 0)
            {
                MessageBox.Show("Pálení nebylo smazáno, není starší více než 10 let.", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            UpdateDistillation();
        }

        private void UpdateDistillation()
        {
            _distillation.Material_Id = (materialCB.SelectedItem as Material).Id;
            _distillation.amount = double.Parse(amountTBox.Text.Replace(".", ","));
            _distillation.ethanolPercentage = double.Parse(percTBox.Text.Replace(".", ","));
            _distillation.distilledVolume = double.Parse(distilledVolumeTBox.Text.Replace(".", ","));
            _distillation.absoluteAlcoholVolume = double.Parse(laaTBox.Text.Replace(".", ","));
            _distillation.price = double.Parse(priceTBox.Text.Replace(".", ","));
            _distillation.payed = payedCB.Checked;
            try
            {
                DistillationTable.Update(_distillation);
                DialogResult = DialogResult.OK;
            }
            catch (DatabaseException)
            {
                MessageBox.Show("Chyba při ukládání změn.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }
            MessageBox.Show("Změny byly úspěšně uloženy.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
