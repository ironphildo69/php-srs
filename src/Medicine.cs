using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace php_srs
{
    class Medicine
    {
        private enum MedKind        //Enum for the types of medicine that will be sold
        {
            Tablet,
            Ointment,
            Syrup
        }

        //private string _id;
        private string _name;
        private int _quantity;
        private double _pprice;         //purchase price of medicine
        private double _sprice;         //sales price of medicine


        public Medicine()
        {
            //_id = "";
            _name = "";
            _quantity = 0;
            _pprice = 0;
            _sprice = 0;
        }

        //public string ID
        //{
            //get
            //{
                //return _id;
            //}
            //set
            //{
                //_id = value;
            //}
        //}

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

        public double pPrice
        {
            get
            {
                return _pprice;
            }
            set
            {
                _pprice = value;
            }
        }

        public double sPrice
        {
            get
            {
                return _sprice;
            }
            set
            {
                _sprice = value;
            }
        }

    }
}
