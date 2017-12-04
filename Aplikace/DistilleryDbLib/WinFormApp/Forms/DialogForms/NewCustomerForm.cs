using DistilleryDbLib;
using DistilleryDbLib.Adapters;
using DistilleryDbLib.Classes;
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
                streetTBox
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
            cityCB.DataSource = CityTable.Select().ToList();
            cityCB.DisplayMember = "name";
            cityCB.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int count = CustomerTable.Select().Where(c => c.personalNumber == perNumTBox.Text).Count();
            if (AddCheck() && count < 1)
            {
                Customer newCustomer = new Customer
                {
                    name = nameTBox.Text,
                    surename = surenameTBox.Text,
                    personalNumber = perNumTBox.Text,
                    phone = phoneTBox.Text,
                    email = emailTBox.Text,
                    street = streetTBox.Text,
                    houseNumber = houseNumTBox.Text,
                    City_Id = (cityCB.SelectedItem as City).Id,
                    registrationDate = DateTime.Now,
                    distilledVolume = 0
                };
                try
                {
                    CustomerTable.Insert(newCustomer);
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
