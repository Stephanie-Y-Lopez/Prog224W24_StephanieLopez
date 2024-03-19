using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog224W24_StephanieLopez
{
    public class Food : Product
    {
        //Field
        public DateTime ExpirationDate { set; get; }

        //Method
        public override string GetProductType()
        {
            return "Food";
        }
    }
}
