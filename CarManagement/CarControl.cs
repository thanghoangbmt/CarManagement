﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;
using DataSource.daos;
using DataSource.dtos;

namespace CarManagement
{
    public partial class CarControl : UserControl
    {
            CarDAO carDAO = new CarDAO();

        public CarControl()
        {
            InitializeComponent();
        }

        private void CarControl_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            List<CarDTO> listCars = carDAO.GetListCar();
            dgvCars.DataSource = listCars;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
