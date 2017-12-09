using System;
using DistilleryLogic;
using System.Windows.Forms;
using DataLayerNetCore.Entities;

namespace WinFormApp.Forms
{
    public partial class DistillationDetail : Form
    {
        private Distillation _distillation;

        public DistillationDetail(int distillationId)
        {
            InitializeComponent();
            _distillation = DistillationLogic.GetDistillation(distillationId);
        }

        private void DistillationDetail_Load(object sender, EventArgs e)
        {
            materialCB.DataSource = MaterialLogic.GetAllMaterial();
            materialCB.DisplayMember = "Name";
            foreach (Material item in materialCB.Items)
            {
                if (item.Id == _distillation.Material_Id)
                {
                    materialCB.SelectedItem = item;
                    break;
                }
            }

            infoLabel.Text = string.Format("Páleni ze dne {0} - {1}", _distillation.Date.ToShortDateString(), _distillation.Customer.Surename);
            nameTBox.Text = _distillation.Customer.Name;
            surenameTBox.Text = _distillation.Customer.Surename;
            adressTbox1.Text = _distillation.Customer.HouseNumber + " " + _distillation.Customer.Street;
            adressTBox2.Text = _distillation.Customer.City.NameZip;

            timeTBox.Text = _distillation.EndTime.Subtract(_distillation.StartTime).ToString();

            amountTBox.Text = _distillation.Amount.ToString("0.00");
            percTBox.Text = _distillation.EthanolPercentage.ToString("0.00");
            distilledVolumeTBox.Text = _distillation.DistilledVolume.ToString("0.00");
            laaTBox.Text = _distillation.AbsoluteAlcoholVolume.ToString("0.00");
            priceTBox.Text = _distillation.Price.ToString("0.00");
            payedCB.Checked = _distillation.Payed;

            seasonTBox.Text = _distillation.Season.Name;
            periodTBox.Text = _distillation.Period.Name;

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void custDetailBtn_Click(object sender, EventArgs e)
        {
            CustomerDetail cd = new CustomerDetail(_distillation.Customer_Id);
            cd.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (DistillationLogic.CanBeDeleted(_distillation))
            {
                DistillationLogic.DeleteDistillation(_distillation);
                Close();
            }
            else
            {
                MessageBox.Show("Pálení nebylo smazáno, není starší více než 10 let.", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            UpdateDistillation();
        }

        private void UpdateDistillation()
        {
            _distillation.Material_Id = (materialCB.SelectedItem as Material).Id;
            _distillation.Amount = double.Parse(amountTBox.Text.Replace(".", ","));
            _distillation.EthanolPercentage = double.Parse(percTBox.Text.Replace(".", ","));
            _distillation.DistilledVolume = double.Parse(distilledVolumeTBox.Text.Replace(".", ","));
            _distillation.AbsoluteAlcoholVolume = double.Parse(laaTBox.Text.Replace(".", ","));
            _distillation.Price = double.Parse(priceTBox.Text.Replace(".", ","));
            _distillation.Payed = payedCB.Checked;
            try
            {
                DistillationLogic.UpdateDistillation(_distillation);
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
