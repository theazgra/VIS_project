using DataLayerNetCore.Entities;
using DistilleryLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinFormApp.Forms.DialogForms
{
    public partial class NewCustomerForm : Form
    {
        private List<TextBox> _requiredTextBoxes;
        public NewCustomerForm()
        {
            InitializeComponent();
            _requiredTextBoxes = new List<TextBox>
            {
                nameTBox,
                surenameTBox,
                perNumTBox,
                houseNumTBox,
                streetTBox,
                tbPswrd,
                tbLogin
            };
        }

        private bool AddCheck()
        {
            foreach (TextBox tb in _requiredTextBoxes)
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void NewCustomerForm_Load(object sender, EventArgs e)
        {
            cityCB.DataSource = CityLogic.GetAllCities();
            cityCB.DisplayMember = "Name";
            cityCB.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!CustomerLogic.GoodPersonalNumber(perNumTBox.Text))
            {
                MessageBox.Show("Nesprávné rodné číslo.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!UserLogic.LoginAvaible(tbLogin.Text))
            {
                MessageBox.Show("Daný login již není k dispozici.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (AddCheck())
            {
                Customer newCustomer = new Customer
                {
                    Name = nameTBox.Text,
                    Surename = surenameTBox.Text,
                    PersonalNumber = perNumTBox.Text,
                    Phone = phoneTBox.Text,
                    Email = emailTBox.Text,
                    Street = streetTBox.Text,
                    HouseNumber = houseNumTBox.Text,
                    City_Id = (cityCB.SelectedItem as City).Id,
                    RegistrationDate = DateTime.Now,
                    DistilledVolume = 0,
                    Login = tbLogin.Text,
                    Password = tbPswrd.Text,
                    UserLevel = UserInfo.Customer
                };
                try
                {
                    CustomerLogic.CreateCustomer(newCustomer);
                    DialogResult = DialogResult.OK;
                }
                catch (DatabaseException)
                {
                    MessageBox.Show("Nepovedlo se vložit záznam.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Nejsou vyplněny všechny potřebné informace.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
