using DataSource.daos;
using DataSource.dtos;
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
    public partial class frmHome : Form
    {
        private AccountDTO account;
        public frmHome()
        {
            InitializeComponent();
        }

        public frmHome(AccountDTO account) : this()
        {
            this.account = account;
            this.carControl1.Hide();
            this.manufacturerControl1.Hide();
        }


        private void frmHome_Load(object sender, EventArgs e)
        {
            lbWelcome.Text = "Hi, " + account.Fullname;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            closeApp();
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeApp();
        }

        private void closeApp()
        {
            DialogResult confirmResult = MessageBox.Show("Do you want to exit program ???",
                                 "Confirm Exit!!",
                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            manufacturerControl1.Hide();

            carControl1.Show();
            carControl1.loadData();
            
            pnSide.Height = btnCar.Height;
            pnSide.Top = btnCar.Top;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            pnSide.Height = btnCategory.Height;
            pnSide.Top = btnCategory.Top;
        }

        private void btnManufacturer_Click(object sender, EventArgs e)
        {
            carControl1.Hide();

            manufacturerControl1.Show();
            manufacturerControl1.loadData();

            pnSide.Height = btnManufacturer.Height;
            pnSide.Top = btnManufacturer.Top;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            pnSide.Height = btnInvoice.Height;
            pnSide.Top = btnInvoice.Top;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnSide.Height = btnCustomer.Height;
            pnSide.Top = btnCustomer.Top;
        }
    }
}
