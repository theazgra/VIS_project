using System;
using DistilleryLogic;
using System.Windows.Forms;
using DataLayerNetCore.Entities;
using System.Linq;

namespace WinFormApp.Forms
{
    public partial class CustomerDetail : Form
    {
        private Customer _customer;

        public CustomerDetail(int customerId)
        {
            InitializeComponent();
            _customer = CustomerLogic.GetCustomer(customerId);
        }

        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            cityCB.DataSource = CityLogic.GetAllCities();
            cityCB.DisplayMember = "Name";
            foreach (City item in cityCB.Items)
            {
                if (item.NameZip == _customer.City.NameZip)
                {
                    cityCB.SelectedItem = item;
                    break;
                }
            }

            cityCB.SelectedItem = _customer.City;

            nameTBox.Text = _customer.Name;
            surenameTBox.Text = _customer.Surename;
            perNumTBox.Text = _customer.PersonalNumber;
            phoneTBox.Text = _customer.Phone;
            emailTBox.Text = _customer.Email;
            streetTBox.Text = _customer.Street;
            houseNumTBox.Text = _customer.HouseNumber;
            regDate.Text = _customer.RegistrationDate.ToShortDateString();
            distilledVolumeTBox.Text = _customer.DistilledVolume.ToString("0.00");

            customerReservationList.DataSource = ReservationLogic.PendingReservations(_customer.Id);
        }

        private void SaveCustomerClick(object sender, EventArgs e)
        {
            _customer.Name = nameTBox.Text;
            _customer.Surename = surenameTBox.Text;
            _customer.PersonalNumber = perNumTBox.Text;
            _customer.Phone = phoneTBox.Text;
            _customer.Email = emailTBox.Text;
            _customer.Street = streetTBox.Text;
            _customer.HouseNumber = houseNumTBox.Text;
            _customer.City_Id = (cityCB.SelectedItem as City).Id;

            try
            {
                CustomerLogic.UpdateCustomer(_customer);
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
