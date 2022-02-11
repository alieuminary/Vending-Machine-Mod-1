using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string Slot {get; set;}
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public int StockAmount { get; set; }
        


        public Product(string line)
        {
            string[] productInfo = line.Split('|');

            this.Slot = productInfo[0];
            this.Name = productInfo[1];
            this.Price = double.Parse(productInfo[2]);
            this.Type = productInfo[3];
            this.StockAmount = 5;

        }





        // message method
        public string SetMessage()
        {
            if(Type == "Chip")
            {
                Message = "Crunch Crunch, Yum!";
            }

            else if(Type == "Candy")
            {
                Message = "Munch Munch, Yum!";
            }

            else if(Type == "Drink")
            {
                Message = "Glug Glug, Yum!";
            }

            else if(Type == "Gum")
            {
                Message = "Chew Chew, Yum!";
            }

            return Message;

        }

        public void DisplayMessage()
        {

            Console.WriteLine(Message);

        }


        
    }
}
