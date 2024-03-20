using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog224W24_StephanieLopez
{
    public class Order
    {
        //Field
        public List<Product> Products { get; set; } = new List<Product>();
        public double totalprice_ { get; set; }

        //Methods 
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public double CalculateTotalPrice()
        {
            double TotalPrice = 0;
            foreach (var product in Products)
            {
                TotalPrice += product.price_;
            }
            return TotalPrice;
        }
    }
}
