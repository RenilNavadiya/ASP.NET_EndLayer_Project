using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SalesmanBO
    {
        //Declaring Order  Variables  
        private int _SalesmanId;
        private string _SalesmanName;
        private string _City;
        private Decimal _Commission;

        // Get and set values  
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
        public string SalesmanName
        {
            get
            {
                return _SalesmanName;
            }
            set
            {
                _SalesmanName = value;
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
        public Decimal Commission
        {
            get
            {
                return _Commission;
            }
            set
            {
                _Commission = value;
            }
        }
    }
}
