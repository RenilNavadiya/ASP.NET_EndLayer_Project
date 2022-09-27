using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SalesmanBL
    {
        public int InsertSalesman(SalesmanBO salesmanBO)
        {
            try
            {
                SalesmanDA salesmanDA = new SalesmanDA();
                return salesmanDA.InsertSalesman(salesmanBO);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteSalesman(int salesmanId)
        {
            try
            {
                SalesmanDA salesmanDA = new SalesmanDA();
                return salesmanDA.DeleteSalesman(salesmanId);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateSalesman(SalesmanBO salesmanBO)
        {
            try
            {
                SalesmanDA salesmanDA = new SalesmanDA();
                return salesmanDA.UpdateSalesman(salesmanBO);
            }
            catch
            {
                return 0;
            }
        }
    }
}
