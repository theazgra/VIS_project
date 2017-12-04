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
using WinFormApp.Forms.DialogForms;

namespace WinFormApp.Forms
{
    public partial class CustomerForm : Form
    {
        private List<Customer> _customerList;
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
            _customerList = CustomerTable.Select().ToList();
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
                _customerList = CustomerTable.SelectBySurename(searchTBox.Text).ToList() ;
                customerGridView.DataSource = _customerList;
            }
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Customer c = customerGridView.CurrentRow.DataBoundItem as Customer;
            if (c != null)
            {
                if (MessageBox.Show("Opravdu chcete smazat zakaznika " + c.surename + " " + c.name + " ?", "Otazka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = CustomerTable.Delete(c.Id);
                    if(i == 0)
                    {
                        MessageBox.Show("Zákazník nemohl být smazát protože má zapsáno pálení.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Reload();
                }
            }
        }

        private void customerGridView_DoubleClick(object sender, EventArgs e)
        {
            Customer c = customerGridView.CurrentRow.DataBoundItem as Customer;
            if (c != null)
            {
                CustomerDetail cd = new CustomerDetail(c.Id);
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
