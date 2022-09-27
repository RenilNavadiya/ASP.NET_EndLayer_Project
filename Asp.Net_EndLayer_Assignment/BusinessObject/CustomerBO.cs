using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CustomerBO
    {
        //Declaring Order  Variables  
        private int _CustomerId;
        private string _CustomerName;
        private string _City;
        private int _Grade;
        private int _SalesmanId;

        // Get and set values  
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
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public int Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
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
