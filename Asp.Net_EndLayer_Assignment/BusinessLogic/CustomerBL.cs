using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CustomerBL
    {
        public int InsertCustomer(CustomerBO customerBO)
        {
            try
            {
                CustomerDA customerDA = new CustomerDA();
                return customerDA.InsertCustomer(customerBO);
                
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteCustomer(int customerId)
        {
            try
            {
                CustomerDA customerDA = new CustomerDA();
                return customerDA.DeleteCustomer(customerId);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateCustomer(CustomerBO customerBO)
        {
            try
            {
                CustomerDA customerDA = new CustomerDA();
                return customerDA.UpdateCustomer(customerBO);

            }
            catch
            {
                return 0;
            }
        }
    }

}
