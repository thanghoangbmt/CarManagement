using DataSource.dtos;
using DataSource.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.daos
{
    public class CarDAO
    {
        public List<CarDTO> GetListCar()
        {
            List<CarDTO> list = null;
            string SQL = "SELECT ID, Model_Name, Price, Produced_Year, Accquired_Date, Engine, Quantity, " +
                "Manufacturer_ID, Tranmission_ID, Type_ID, Category_ID, Fuel_ID, Status_ID FROM Cars";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    Car_ManufacturerDAO car_ManufacturerDAO = new Car_ManufacturerDAO();
                    Car_TranmissionDAO car_TranmissionDAO = new Car_TranmissionDAO();
                    Car_TypeDAO car_TypeDAO = new Car_TypeDAO();
                    Car_CategoryDAO car_CategoryDAO = new Car_CategoryDAO();
                    Car_FuelsDAO car_FuelsDAO = new Car_FuelsDAO();
                    Car_StatusDAO car_StatusDAO = new Car_StatusDAO();
                    while (rd.Read())
                    {
                        if (list == null)
                            list = new List<CarDTO>();
                        CarDTO carDTO = new CarDTO
                        {
                            ID = rd.GetInt32(0),
                            Model_Name = rd.GetString(1),
                            Price = rd.GetDouble(2),
                            Produced_Year = rd.GetInt32(3),
                            Accquired_Date = rd.GetDateTime(4),
                            Engine = rd.GetInt32(5),
                            Quantity = rd.GetInt32(6),
                            Manufacturer_Name = car_ManufacturerDAO.GetManufacturerNameByID(rd.GetInt32(7)),
                            Tranmission_Description = car_TranmissionDAO.GetTranmissionDescriptionByID(rd.GetInt32(8)),
                            Type_Description = car_TypeDAO.GetTypeDescriptionByID(rd.GetInt32(9)),
                            Category_Description = car_CategoryDAO.GetCategoryDescriptionByID(rd.GetInt32(10)),
                            Fuel_Description = car_FuelsDAO.GetFuelDescriptionByID(rd.GetInt32(11)),
                            Status_Description = car_StatusDAO.GetStatusDescriptionByID(rd.GetInt32(12))
                        };

                        list.Add(carDTO);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
