using DataLayerNetCore.Entities;
using DistilleryLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinFormApp.Forms.DialogForms;

namespace WinFormApp.Forms
{
    public partial class CustomerForm : Form
    {
        private ICollection<Customer> _customerList;
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            NewCustomerForm ncf = new NewCustomerForm();
            if (ncf.ShowDialog() == DialogResult.OK)
            {
                Reload();
            }
        }

        private void Reload()
        {
            _customerList = CustomerLogic.GetAllCustomers();
            customerGridView.DataSource = _customerList;
        }

        private void searchTBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTBox.Text))
            {
                Reload();
            }
            else
            {
                _customerList =
                    _customerList.Where(c => c.Surename.StartsWith(searchTBox.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();

                customerGridView.DataSource = _customerList;
            }
            
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (customerGridView.CurrentRow.DataBoundItem is Customer selectedCustomer)
            {
                if (MessageBox.Show("Opravdu chcete smazat zakaznika " + 
                    selectedCustomer.Surename + " " + selectedCustomer.Name + " ?", 
                    "Otazka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CustomerLogic.CanBeDeleted(selectedCustomer.Id))
                    {
                        CustomerLogic.DeleteCustomer(selectedCustomer);
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("Zákazník nemohl být smazát protože se k němu vážou záznamy.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void CustomerGridView_DoubleClick(object sender, EventArgs e)
        {
            if (customerGridView.CurrentRow.DataBoundItem is Customer selectedCustomer)
            {
                CustomerDetail cd = new CustomerDetail(selectedCustomer.Id);
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
            }
        }

        private void ReloadClick(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
