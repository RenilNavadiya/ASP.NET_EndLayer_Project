using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDA
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString);

        public int InsertCustomer(CustomerBO customerBO)
        {
            try
            {

                SqlCommand command = new SqlCommand("sp_InsertCustomerData", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerBO.CustomerId;
                command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customerBO.CustomerName;
                command.Parameters.Add("@CustomerCity", SqlDbType.NVarChar).Value = customerBO.City;
                command.Parameters.Add("@Grade", SqlDbType.Int).Value = customerBO.Grade;
                command.Parameters.Add("@SalesmanID", SqlDbType.Int).Value = customerBO.SalesmanId;

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int DeleteCustomer(int customerId)
        {
            try
            {
                string query = $"DELETE FROM customer WHERE customer_id = {customerId}";

                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public int UpdateCustomer(CustomerBO customerBO)
        {
            try
            {

                SqlCommand command = new SqlCommand("sp_UpdateCustomer", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerBO.CustomerId;
                command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customerBO.CustomerName;
                command.Parameters.Add("@CustomerCity", SqlDbType.NVarChar).Value = customerBO.City;
                command.Parameters.Add("@Grade", SqlDbType.Int).Value = customerBO.Grade;
                command.Parameters.Add("@SalesmanId", SqlDbType.Int).Value = customerBO.SalesmanId;

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
