using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;


namespace Prog224W24_StephanieLopez
{
    public class Receipt
    {
        //Fields
        public Order order_ { get; set; }
        public double totalprice_ { get; set; }

        //Method
        public override string ToString()
        {
            return $"Order Total: ${totalprice_}";
        }
    }
}
