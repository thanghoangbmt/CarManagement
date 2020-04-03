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
    public class CustomerDAO
    {
        public List<CustomerDTO> GetListCustomer()
        {
            List<CustomerDTO> list = null;
            string SQL = "SELECT ID, Fullname, Phone, Email FROM Customers";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            if (list == null)
                                list = new List<CustomerDTO>();
                            CustomerDTO cusDTO = new CustomerDTO
                            {
                                ID = rd.GetInt32(0),
                                Fullname = rd.GetString(1),
                                Phone = rd.GetString(2),
                                Email = rd.GetString(3)
                            };
                            list.Add(cusDTO);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public String FindNameByID(int id)
        {
            string name = null;
            string SQL = "SELECT Fullname FROM Customers WHERE ID = @ID";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        if (rd.Read())
                        {
                            name = rd.GetString(0);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return name;
        }
    }
}
