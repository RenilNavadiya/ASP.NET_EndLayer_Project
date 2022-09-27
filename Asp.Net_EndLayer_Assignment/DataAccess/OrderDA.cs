using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess
{
    public class OrderDA
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnectionString"].
            ConnectionString);

        public int InserOrder(OrderBO orderBO)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_InsertOrdersData", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrderNo", SqlDbType.Int).Value = orderBO.OrderNumber;
                command.Parameters.Add("@PurchaseAmount", SqlDbType.Decimal).Value = orderBO.PurchaseAmount;
                command.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orderBO.OrderDate;
                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = orderBO.CustomerId;
                command.Parameters.Add("@SalesmanID", SqlDbType.Int).Value = orderBO.SalesmanId;

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

        public int DeleteOrder(int orderNumber)
        {
            try
            {
                string query = $"DELETE FROM orders WHERE order_no = {orderNumber}";

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

        public int UpdateOrder(OrderBO orderBO)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_UpdateOrder", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrderNo", SqlDbType.Int).Value = orderBO.OrderNumber;
                command.Parameters.Add("@PurchaseAmount", SqlDbType.Decimal).Value = orderBO.PurchaseAmount;
                command.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orderBO.OrderDate;
                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = orderBO.CustomerId;
                command.Parameters.Add("@SalesmanID", SqlDbType.Int).Value = orderBO.SalesmanId;

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
