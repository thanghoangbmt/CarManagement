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
    public partial class frmEditCar : Form
    {
        public frmEditCar()
        {
            InitializeComponent();
        }

        public frmEditCar(CarDTO car) : this()
        {

        }

        private void frmEditCar_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            Car_ManufacturerDAO car_ManufacturerDAO = new Car_ManufacturerDAO();
            Car_CategoryDAO car_CategoryDAO = new Car_CategoryDAO();
            Car_FuelsDAO car_FuelsDAO = new Car_FuelsDAO();
            Car_TranmissionDAO car_TranmissionDAO = new Car_TranmissionDAO();
            Car_TypeDAO car_TypeDAO = new Car_TypeDAO();
            Car_StatusDAO car_StatusDAO = new Car_StatusDAO();

            List<Car_ManufacturerDTO> car_ManufacturerDTOs = car_ManufacturerDAO.GetListManufacturer();
            cbManufacturer.Items.Clear();
            foreach (Car_ManufacturerDTO manufacturerDTO in car_ManufacturerDTOs)
            {
                cbManufacturer.Items.Add(manufacturerDTO.Name);
            }
            cbManufacturer.SelectedIndex = 0;


            List<Car_CategoryDTO> car_CategoryDTOs = car_CategoryDAO.GetListCategory();
            cbCategory.Items.Clear();
            foreach (Car_CategoryDTO categoryDTO in car_CategoryDTOs)
            {
                cbCategory.Items.Add(categoryDTO.Description);
            }
            cbCategory.SelectedIndex = 0;


            List<Car_FuelsDTO> car_Fuels = car_FuelsDAO.GetListFuel();
            cbFuel.Items.Clear();
            foreach (Car_FuelsDTO fuelsDTO in car_Fuels)
            {
                cbFuel.Items.Add(fuelsDTO.Description);
            }
            cbFuel.SelectedIndex = 0;


            List<Car_TranmissionDTO> car_TranmissionDTOs = car_TranmissionDAO.GetListTranmission();
            cbTranmission.Items.Clear();
            foreach (Car_TranmissionDTO tranmissionDTO in car_TranmissionDTOs)
            {
                cbTranmission.Items.Add(tranmissionDTO.Description);
            }
            cbTranmission.SelectedIndex = 0;

            List<Car_TypeDTO> car_TypeDTOs = car_TypeDAO.GetListType();
            cbType.Items.Clear();
            foreach (Car_TypeDTO typeDTO in car_TypeDTOs)
            {
                cbType.Items.Add(typeDTO.Description);
            }
            cbType.SelectedIndex = 0;

            List<Car_StatusDTO> car_StatusDTOs = car_StatusDAO.GetListStatus();
            cbType.Items.Clear();
            foreach (Car_StatusDTO statusDTO in car_StatusDTOs)
            {
                cbType.Items.Add(statusDTO.Description);
            }
            cbStatus.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
