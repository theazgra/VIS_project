using System;
using DistilleryLogic;
using System.Windows.Forms;
using DataLayerNetCore.Entities;

namespace WinFormApp.Forms.DialogForms
{
    public partial class LoginForm : Form
    {
        public UserInfo LoggedUser { get; private set; } = null;

        public LoginForm()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.StoredLogin))
                tbLogin.Text = Properties.Settings.Default.StoredLogin;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.StoredPassword))
            {
                tbPassword.Text = Properties.Settings.Default.StoredPassword;
                chBRememberMe.Checked = true;
            }
        }

        private void LogIn(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Není vyplněn login", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Není vyplněno heslo", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserLogic.LoginUser(tbLogin.Text, tbPassword.Text) is UserInfo user)
            {
                if (chBRememberMe.Checked)
                {
                    Properties.Settings.Default.StoredLogin = tbLogin.Text;
                    Properties.Settings.Default.StoredPassword = tbPassword.Text;
                }
                else
                {
                    Properties.Settings.Default.StoredLogin = string.Empty;
                    Properties.Settings.Default.StoredPassword = string.Empty;
                }
                Properties.Settings.Default.Save();


                LoggedUser = user;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Nesprávná kombinace jména a hesla", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
