using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderBO
    {
        //Declaring Order  Variables  
        private int _OrderNumber;
        private decimal _PurchaseAmount;
        private DateTime _OrderDate;
        private int  _CustomerId;
        private int  _SalesmanId;

        // Get and set values  
        public int OrderNumber
        {
            get
            {
                return _OrderNumber;
            }
            set
            {
                _OrderNumber = value;
            }
        }
        public decimal PurchaseAmount
        {
            get
            {
                return _PurchaseAmount;
            }
            set
            {
                _PurchaseAmount = value;
            }
        }
        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
            }
        }
        public int CustomerId
        {
            get
            {
                return _CustomerId;
            }
            set
            {
                _CustomerId = value;
            }
        }
        public int SalesmanId
        {
            get
            {
                return _SalesmanId;
            }
            set
            {
                _SalesmanId = value;
            }
        }
    }
}
