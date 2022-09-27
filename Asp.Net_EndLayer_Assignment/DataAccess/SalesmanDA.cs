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
    public class SalesmanDA
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryConnectionString"].
            ConnectionString);

        public int InsertSalesman(SalesmanBO salesmanBO)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_insertSalesmanData", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SalesmanID", SqlDbType.Int).Value = salesmanBO.SalesmanId;
                command.Parameters.Add("@SalesmanName", SqlDbType.NVarChar).Value = salesmanBO.SalesmanName;
                command.Parameters.Add("@SalesmanCity", SqlDbType.NVarChar).Value = salesmanBO.City;
                command.Parameters.Add("@Commission", SqlDbType.Decimal).Value = salesmanBO.Commission;

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

        public int DeleteSalesman(int salesmanId)
        {
            try
            {
                string query = $"DELETE FROM salesman WHERE salesman_id = {salesmanId}";

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

        public int UpdateSalesman(SalesmanBO salesmanBO)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_UpdateSalesman", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SalesmanId", SqlDbType.Int).Value = salesmanBO.SalesmanId;
                command.Parameters.Add("@SalesmanName", SqlDbType.NVarChar).Value = salesmanBO.SalesmanName;
                command.Parameters.Add("@SalesmanCity", SqlDbType.NVarChar).Value = salesmanBO.City;
                command.Parameters.Add("@Commission", SqlDbType.Decimal).Value = salesmanBO.Commission;

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
