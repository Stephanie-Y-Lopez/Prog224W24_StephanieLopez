using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Prog224W24_StephanieLopez
{
    public class Inventory : IEnumerable<Product>
    {
        //Field
        public List<Product> Products { get; set; }

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

        //Figured out I had to add in more code because when I did case 4 'exit' it crashed, so I put in a try and catch to help with the deserialization of JSON. And it doesnt crash anymore yay!
        public void LoadFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    Products = JsonConvert.DeserializeObject<List<Product>>(json);
                }
                else
                {
                    Console.WriteLine("JSON file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading inventory data: {ex.Message}");
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
