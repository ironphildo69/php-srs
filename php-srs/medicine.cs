using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php_srs
{
    class Medicine
    {
        
            private string _id;
            private string _name;
            private int _quantity;

        public Medicine()
        {
            _id = "";
            _name = "";
            _quantity = 0;
        }

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
    
    }
}
