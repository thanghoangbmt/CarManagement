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
    public class Car_TypeDAO
    {
        public int GetTypeIDByDescription(string Description)
        {
            int result = 0;
            string SQL = "SELECT ID FROM Car_Types WHERE Description = @Description";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Description", Description);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.Read())
                    {
                        result = rd.GetInt32(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public string GetTypeDescriptionByID(int ID)
        {
            string result = "";
            string SQL = "SELECT Description FROM Car_Types WHERE ID = @ID";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rd.Read())
                    {
                        result = rd.GetString(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
