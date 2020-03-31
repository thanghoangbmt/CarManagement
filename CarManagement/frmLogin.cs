using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarManagement
{
    public partial class frmLogin : Form
    {
        private CarManagementEntities db = new CarManagementEntities();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) 
        {
            string UserID = txtUserID.Text;
            string Password = txtPassword.Text;

            if (string.IsNullOrEmpty(UserID))
            {
                MessageBox.Show("Please input Username!");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please input Password!");
                return;
            }

            Account account = db.Accounts.FirstOrDefault(acc => acc.UserID == UserID && acc.Password == Password);
            if (account != null)
            {
                frmHome frmHome = new frmHome(account);
                frmHome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect!");
            }

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Do you want to exit program ???",
                                     "Confirm Exit!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Dispose();
            } 
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
