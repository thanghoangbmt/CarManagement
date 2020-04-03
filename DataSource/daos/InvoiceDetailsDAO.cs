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
    public class InvoiceDetailsDAO
    {
        public List<InvoiceDetailsDTO> GetListInvoiceDetailByInvoiceID(int invoiceID)
        {
            List<InvoiceDetailsDTO> list = null;
            string SQL = "SELECT ID, Car_ID, Invoice_ID, Unit_Price, Quantity FROM Invoice_Details WHERE Invoice_ID = @ID";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", invoiceID);
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
                                list = new List<InvoiceDetailsDTO>();
                            InvoiceDetailsDTO invoiceDetailsDTO = new InvoiceDetailsDTO
                            {
                                ID = rd.GetInt32(0),
                                Car_ID = rd.GetInt32(1),
                                Invoice_ID = rd.GetInt32(2),
                                Unit_Price = rd.GetDouble(3),
                                Quantity = rd.GetInt32(4)
                            };

                            list.Add(invoiceDetailsDTO);
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

        public double GetTotalPriceOfInvoice(int invoiceID)
        {
            double totalPrice = 0;
            string SQL = "SELECT SUM(Unit_Price * Quantity) as Total FROM Invoice_Details WHERE Invoice_ID = @ID";
            SqlConnection cnn = DBUtils.GetConnection();
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", invoiceID);
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
                            totalPrice = rd.GetDouble(0);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return totalPrice;
        }
    }
}
