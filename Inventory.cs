using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog224W24_StephanieLopez
{
    public class Inventory : IEnumerable<Product>
    {
        //Field
        public List<Product> Products { set; get; }

        public Inventory()
        {
            Products = new List<Product>();
        }


        //Methods!
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void SaveToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(Products);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }

        //To fix error caused by Inventory being inherited from IEnumerable<>
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
