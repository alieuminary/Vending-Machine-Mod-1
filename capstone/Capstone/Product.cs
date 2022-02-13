using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string SlotCode { get; set; }
        public string BrandName { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int Supply { get; set; }
        public string Message { get; set; }


        public Product(string[] lineFromStream)
        {
            SlotCode = lineFromStream[0];
            BrandName = lineFromStream[1];
            Price = double.Parse(lineFromStream[2]);
            Type = lineFromStream[3];
            Supply = 5;
            

            Message = " ";

            if (Type == "Chip")
            {
                Message = "Crunch Crunch, Yum!";
            }

            else if (Type == "Candy")
            {
                Message = "Munch Munch, Yum!";
            }

            else if (Type == "Drink")
            {
                Message = "Glug Glug, Yum!";
            }

            else if (Type == "Gum")
            {
                Message = "Chew Chew, Yum!";
            }

        }
    }
}