using DistilleryDbLib.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DistilleryDbLib.Classes;
using DistilleryDbLib;

namespace WinFormApp.Forms
{
    public partial class CustomerDetail : Form
    {
        private Customer _customer;

        public CustomerDetail(int customerId)
        {
            InitializeComponent();
            _customer = CustomerTable.Select(customerId);
        }

        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            cityCB.DataSource = CityTable.Select().ToList();
            cityCB.DisplayMember = "name";
            foreach (City item in cityCB.Items)
            {
                if (item.nameZip == _customer.City.nameZip)
                {
                    cityCB.SelectedItem = item;
                    break;
                }
            }

            cityCB.SelectedItem = _customer.City;

            nameTBox.Text = _customer.name;
            surenameTBox.Text = _customer.surename;
            perNumTBox.Text = _customer.personalNumber;
            phoneTBox.Text = _customer.phone;
            emailTBox.Text = _customer.email;
            streetTBox.Text = _customer.street;
            houseNumTBox.Text = _customer.houseNumber;
            regDate.Text = _customer.registrationDate.ToShortDateString();
            distilledVolumeTBox.Text = _customer.distilledVolume.ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _customer.name = nameTBox.Text;
            _customer.surename = surenameTBox.Text;
            _customer.personalNumber = perNumTBox.Text;
            _customer.phone = phoneTBox.Text;
            _customer.email = emailTBox.Text;
            _customer.street = streetTBox.Text;
            _customer.houseNumber = houseNumTBox.Text;
            _customer.City_Id = (cityCB.SelectedItem as City).Id;
            try
            {
                CustomerTable.Update(_customer);
                MessageBox.Show("Změny byly úspěšně uloženy.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (DatabaseException)
            {
                MessageBox.Show("Chyba při ukládání změn.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }
            Close();
        }
    }
}
