using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderBL
    {
        public int InsertOrder(OrderBO orderBO)
        {
            try
            {
                OrderDA orderDA = new OrderDA();
                return orderDA.InserOrder(orderBO);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteOrder(int orderNumber)
        {
            try
            {
                OrderDA orderDA = new OrderDA();
                return orderDA.DeleteOrder(orderNumber);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateOrder(OrderBO orderBO)
        {
            try
            {
                OrderDA orderDA = new OrderDA();
                return orderDA.UpdateOrder(orderBO);
            }
            catch
            {
                return 0;
            }
        }
    }
}
