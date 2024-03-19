using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog224W24_StephanieLopez
{
    public abstract class Product
    {
        //Fields
        public string name_ { set; get; }
        public double price_ { set; get; }

        //Methods
        public override string ToString()
        {
            return $"{name_}: ${price_}";
        }

        public abstract string GetProductType();
    }
}
