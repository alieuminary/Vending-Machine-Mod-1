using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product 
    {
        public string Slot { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string StockAmount { get; set; }
        

        public Product(string slot, string name, double price, string type) // to retrieve data from csv file
        {
            Slot = slot;
            Name = name;
            Price = price;
            Type = type;
        }

        // message method




        
    }
}
