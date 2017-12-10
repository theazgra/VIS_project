using System;
using DistilleryLogic;
using System.Windows.Forms;
using DataLayerNetCore.Entities;
using WinFormApp.Forms.DialogForms;
using System.Globalization;
using System.Collections.Generic;

namespace WinFormApp.Forms
{
    public partial class NewDistillationForm : Form
    {
        private Distillation _distillation;

        private List<TextBox> _reqTBs;

        public NewDistillationForm()
        {
            InitializeComponent();

            Season season = AdministrationLogic.GetActiveSeason();
            Period period = AdministrationLogic.GetActivePeriod();

            _distillation = new Distillation
            {
                StartTime = DateTime.Now,
                Date = DateTime.Today.Date,
                Payed = false,
                Season = season,
                Season_Id = season.Id,
                Period = period,
                Period_Id = period.Id
            };

            _reqTBs = new List<TextBox>
            {
                tbAmount,
                tbDistVolume,
                tbPercAlc
            };


            materialCB.DataSource = MaterialLogic.GetAllMaterial();
            materialCB.DisplayMember = "Name";

            

            tbPeriod.Text = period.Name;
            tbSeason.Text = season.Name;
        }


        private void AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                double limit = 30 - customer.DistilledVolume;
                if (limit <= 0)
                {
                    MessageBox.Show("Zákazník překročil limit!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                _distillation.Customer = customer;
                _distillation.Customer_Id = customer.Id;

                tbName.Text = customer.Name;
                tbSurename.Text = customer.Surename;
                tbLaaLimit.Text = (limit).ToString();

                MessageBox.Show("Zákazník může ještě vypálit " + tbLaaLimit.Text + " L.A.A. .", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SelectCustClick(object sender, EventArgs e)
        {
            CustomerForm cf = new CustomerForm(true);
            if (cf.ShowDialog() == DialogResult.OK)
            {
                AddCustomer(cf.SelectedCustomer);
            }
        }

        private void CreateCust(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm(true);
            if (ncf.ShowDialog() == DialogResult.OK)
            {
                AddCustomer(ncf.NewCustomer);
            }
        }

        private void CalcLaa(object sender, EventArgs e)
        {
            if (double.TryParse(tbDistVolume.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double volume) &&
                double.TryParse(tbPercAlc.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double perc))
            {
                if (volume < 0 || perc < 0 || perc > 100)
                {
                    MessageBox.Show("Nesprávný vstup", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _distillation.DistilledVolume = volume;
                _distillation.EthanolPercentage = perc;
                _distillation.AbsoluteAlcoholVolume = volume * (perc / 100.0);
                _distillation.Price = _distillation.AbsoluteAlcoholVolume * 130.25;

                tbPrice.Text = _distillation.Price.ToString();
                tbLAA.Text = _distillation.AbsoluteAlcoholVolume.ToString();
            }
        }

        private void SaveDist(object sender, EventArgs e)
        {
            if (CanAdd())
            {
                if (!double.TryParse(tbAmount.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double amount))
                {
                    MessageBox.Show("Nesprávný vstup pro množství materiálu", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _distillation.Amount = amount;

                if (materialCB.SelectedItem is Material material)
                {
                    _distillation.Material = material;
                    _distillation.Material_Id = material.Id;
                }

                _distillation.EndTime = DateTime.Now;
                _distillation.Payed = chBPayed.Checked;

                DistillationLogic.CreateDistillation(_distillation);

                _distillation.Customer.DistilledVolume += _distillation.AbsoluteAlcoholVolume;

                CustomerLogic.UpdateCustomer(_distillation.Customer);


                MessageBox.Show("Pálení bylo zapsáno. Cena je " + _distillation.Price.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Nejsou vyplněny všechny položky", "Upozorneni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CanAdd()
        {
            foreach (TextBox tb in _reqTBs)
            {
                if (string.IsNullOrEmpty(tb.Text))
                    return false;
            }
            return true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialCB.SelectedItem is Material material)
            {
                _distillation.Material = material;
                _distillation.Material_Id = material.Id;
            }
        }
    }
}
