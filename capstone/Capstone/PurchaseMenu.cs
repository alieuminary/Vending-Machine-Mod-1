using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu : DisplayServices
    {

        public PurchaseMenu() : base("(1) Feed Money", "(2) Select Product", "(3) Finish Transaction", " ")
        {


        }



        public void PurchaseMenuNav()
        {

            Console.Clear();

            Console.WriteLine(base.MenuSelect1);
            Console.WriteLine(base.MenuSelect2);
            Console.WriteLine(base.MenuSelect3);

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    var feedMoneyMenu = new FeedMoneyMenu();
                    feedMoneyMenu.FeedMoneyMenuNav();
                    break;


            }


            //public string MainMenuNav()
            //{
            //    string userInput = Console.ReadLine();

            //    if (userInput == "1")
            //    {

            //        return Console.WriteLine("DisplayMenu");

            //    }

            //    if (userInput == "2")
            //    {

            //        return Console.WriteLine();

            //    }

            //}




        }
    }
}
