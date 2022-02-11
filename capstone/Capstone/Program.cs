using System;
using System.Collections.Generic;
using System.IO;


namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            //Grabbing the stock file

            string directory = @"C:\Users\Student\workspace\mod-1-capstone-orange-team-0\Capstone";
            string stockFile = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, stockFile);

            //STOCKING THE MACHINE

            List<Product> Products = new List<Product>();

            using (StreamReader sr = new StreamReader(fullPath))
            {

                while (!sr.EndOfStream)

                {
                    string line = sr.ReadLine();

                    Products.Add(new Product(line));
                }

            }

            //Testing to see if Products list was created:
            //
            //foreach (Product product in Products)
            //{
            //    Console.WriteLine($"{product.Slot}");
            //}

            //it works. Can we use in DisplayName?

            //___________
            //Starting UX
            //***********

            MainMenu userMainMenu = new MainMenu();
            PurchaseMenu purchaseMenu = new PurchaseMenu();
            FeedMoneyMenu feedMoneyMenu = new FeedMoneyMenu();

            double userMoney = 0;


            //Main Menu


            Console.WriteLine(userMainMenu.MenuSelect1);
            Console.WriteLine(userMainMenu.MenuSelect2);
            Console.WriteLine(userMainMenu.MenuSelect3);

            string userInput = Console.ReadLine();


            //Display Products Menu

            if (userInput == "1")
            {

                foreach (Product product in Products)
                {
                    Console.WriteLine(product.Name + " " + product.StockAmount);
                }

                Console.ReadLine();
            }



            //Purchase Menu

            else if (userInput == "2")
            {

                Console.WriteLine(purchaseMenu.MenuSelect1);
                Console.WriteLine(purchaseMenu.MenuSelect2);
                Console.WriteLine(purchaseMenu.MenuSelect3);

                string purchaseMenuInput = Console.ReadLine();


             //Feed Money Menu

                if (purchaseMenuInput == "1")
                {

                    Console.WriteLine("Please select an amount to deposit");
                    Console.WriteLine(feedMoneyMenu.MenuSelect1);
                    Console.WriteLine(feedMoneyMenu.MenuSelect2);
                    Console.WriteLine(feedMoneyMenu.MenuSelect3);

                    string moneyInserted = Console.ReadLine();

                    if (moneyInserted == "1")
                    {
                        userMoney += 1;
                    }

                    else if (moneyInserted == "2")
                    {
                        userMoney += 5;
                    }

                    else if (moneyInserted == "3")
                    {
                        userMoney += 10;
                    }

                }

                Console.WriteLine($"You currently have ${userMoney} to spend... Choose wisely.");
                Console.WriteLine("Add More Money? (Y\\N)");

                string addMoreMoney = Console.ReadLine();
                
                if (addMoreMoney == "Y" || addMoreMoney == "y")
                {

                    Console.WriteLine("Please select an amount to deposit");
                    Console.WriteLine(feedMoneyMenu.MenuSelect1);
                    Console.WriteLine(feedMoneyMenu.MenuSelect2);
                    Console.WriteLine(feedMoneyMenu.MenuSelect3);

                    string moneyInserted = Console.ReadLine();

                    if (moneyInserted == "1")
                    {
                        userMoney += 1;
                    }

                    else if (moneyInserted == "2")
                    {
                        userMoney += 5;
                    }

                    else if (moneyInserted == "3")
                    {
                        userMoney += 10;
                    }

                }

                Console.WriteLine($"You currently have ${userMoney} to spend... Choose wisely.");



                if (addMoreMoney == "N" || addMoreMoney == "n")
                {
                    Console.WriteLine(purchaseMenu.MenuSelect1);
                    Console.WriteLine(purchaseMenu.MenuSelect2);
                    Console.WriteLine(purchaseMenu.MenuSelect3);

                }


                else if (userInput == "3")
                {

                    Environment.Exit(0);
                    Console.WriteLine();
                }

            }
        }
    }
}
