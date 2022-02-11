using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu : DisplayServices
    {

        public MainMenu() : base("(1) Display Vending Machine Items", "(2) Purchase", "(3) Exit", " ")
        {
         

        }

        public void MainMenuNav()
        {

            Console.Clear();

            Console.WriteLine(base.MenuSelect1);
            Console.WriteLine(base.MenuSelect2);
            Console.WriteLine(base.MenuSelect3);

            string userInput = Console.ReadLine();
            
            switch (userInput)
            {

                case "1":
                        break;

                case "2":
                    var purchaseMenu = new PurchaseMenu();
                    purchaseMenu.PurchaseMenuNav();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("_______________________________________________________");
                    Console.WriteLine(" Umbrella Corp. appreciates your service. STAY HUNGRY! ");
                    Console.WriteLine("*******************************************************");
                    Environment.Exit(0);
                    break;
            }

            MainMenuNav();

        }



    }
}
