using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        // properties & attributes

        public double CurrentBalance { get; set; }
        public double TotalSpent { get; set; }
        public string LogAction { get; set; }
        public double AmountBeforeAction { get; set; }

        public List<Product> Stock = new List<Product>();



        public int Quarter { get; set; }
        public int Dime { get; set; }
        public int Nickel { get; set; }

        Logger Log = new Logger();




        //Stock Method
        public void StockTheMachine()
        {
            try
            {

                const string relativeFileName = @"..\..\..\..\vendingmachine.csv";
                string directory = Environment.CurrentDirectory;
                string filename = Path.Combine(directory, relativeFileName);
                string fullPath = Path.GetFullPath(filename);



                using (StreamReader sr = new StreamReader(fullPath))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemInfo = line.Split('|');

                        Stock.Add(new Product(itemInfo));

                    }

                }

            }

            catch (IOException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("File Not Found");
            }
        }



        //Financial
        public void FeedMoney(int amountOfMoney)
        {
            Log.AmountBeforeAction = CurrentBalance;
            CurrentBalance += amountOfMoney;
            Log.LogAction = "FEED MONEY:";
            Log.LogIt();
        }


        public void SpendMoney(double price)
        {
            CurrentBalance -= price;
        }

        public void TrackSpending(double productPrice)
        {
            TotalSpent += productPrice;
        }


        public void ReturnChange(double currentBalance)
        {
            double changeToReturn = currentBalance * 100;
            Quarter = (int)(changeToReturn / 25);

            changeToReturn -= (Quarter * 25);

            Dime = (int)(changeToReturn / 10);

            changeToReturn -= (Dime * 10);

            Nickel = (int)(changeToReturn / 5);

            CurrentBalance = 0;
        }



        //Display

        public void MainMenu()
        {

            Console.Clear();
            Console.WriteLine("UMBRELLA CORP. PROUDLY PRESENTS THE");
            Console.WriteLine(@" _ _              _            __ __        _    _        ___  ___  ___ 
| | | ___ ._ _  _| | ___  ___ |  \  \ ___ _| |_ <_> ___  < . >|   ||   |
| ' |/ ._>| ' |/ . |/ . \|___||     |<_> | | |  | |/ | ' / . \| / || / |
|__/ \___.|_|_|\___|\___/     |_|_|_|<___| |_|  |_|\_|_. \___/`___'`___'");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type 1 to view all we have to offer.");
            Console.WriteLine("Type 2 to insert money and make a purchase.");
            Console.WriteLine("Type 3 to walk away.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(3) Exit");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***any and all unusual side-effects are purely coincidental***");




            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    DisplayItems();
                    break;

                case "2":
                    PurchaseMenu();
                    break;

                case "3":
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                    break;

            }

        }
         
        public void DisplayItems()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Feel free to stare at our delicious products as long as your heart desires...");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************************");
            Console.WriteLine("Press < ENTER > to return to Main Menu");
            Console.WriteLine("***************************************");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("--------------------------------------");

            foreach (Product product in Stock)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{product.BrandName} ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" {product.Supply}/5 remaining");
                Console.ResetColor(); ;
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************************");
            Console.WriteLine("Press < ENTER > to return to Main Menu");
            Console.WriteLine("***************************************");
            Console.ResetColor();

            string returnToMain = Console.ReadLine();

            MainMenu();

        }

        public void PurchaseMenu()
        {

            Console.Clear();
            Console.WriteLine("Type 1 to insert money into the machine.");
            Console.WriteLine("Type 2 to select and purchase products.");
            Console.WriteLine("Type 3 to finish your transaction and recieve any change.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) Insert Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(3) Finish Transaction");
            Console.ResetColor();

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    FeedMoneyMenu(); // FeedMoneyMenu
                    break;

                case "2":
                    SelectAndBuyItem();
                    break;

                case "3":
                    FinishTransaction();
                    break;

            }
        }

        public void FeedMoneyMenu()
        {
            Console.Clear();
            Console.WriteLine("Here, you can insert all of your moneis!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Money in Machine:  ${CurrentBalance}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) Insert $1");
            Console.WriteLine("(2) Insert $2");
            Console.WriteLine("(3) Insert $5");
            Console.WriteLine("(4) Insert $10");
            Console.ResetColor();
            Console.WriteLine();

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    FeedMoney(1);
                    break;

                case "2":
                    FeedMoney(2);
                    break;

                case "3":
                    FeedMoney(5);
                    break;

                case "4":
                    FeedMoney(10);
                    break;
            }

            Console.Clear();
            Console.WriteLine($"Money in Machine:  ${CurrentBalance}");
            Console.WriteLine();
            Console.WriteLine("... Spend wisely!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do you want to add more money? (Y\\N)");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Awaiting response...");

            string addMoney = Console.ReadLine();
            if (addMoney == "y" || addMoney == "Y")
            {
                FeedMoneyMenu();
            }

            else if (addMoney == "n" || addMoney == "N")
            {
                PurchaseMenu();
            }

            FeedMoneyMenu();

        }

        public void SelectAndBuyItem() // NEED TO ADD ERROR MESSAGES (for invalid code)
        {

            Console.Clear();


            //Select Product Instructions
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Money in Machine:  ${CurrentBalance}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("To purchase a product: Type it's CODE, then press <ENTER>");
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();


            //Display Products to choose from 
            foreach (Product product in Stock)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"CODE: {product.SlotCode}");
                Console.ResetColor();
                Console.WriteLine($" | {product.BrandName}:  ${product.Price}");
            }


            //User Selects Product
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("To purchase a product: Type it's CODE, then press <ENTER>");
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();

            string slotCode = Console.ReadLine();
            int warnings = 0;

            //Product is sold 
            foreach (Product product in Stock)
            {
                if (slotCode.ToUpper() == product.SlotCode && product.Supply > 0 && product.Price < CurrentBalance)
                {
                    AmountBeforeAction = CurrentBalance;
                    LogAction = $"{product.BrandName} {product.SlotCode}";
                    SpendMoney(product.Price);
                    product.Supply -= 1;
                    TrackSpending(product.Price);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Please retrieve your {product.BrandName} from the tray... {product.Message}");
                    Console.ResetColor();
                    Console.WriteLine();

                    LogIt();
                }

                else if (slotCode.ToUpper() == product.SlotCode && product.Supply == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{(product.BrandName).ToUpper()} IS");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("---------");
                    Console.WriteLine("SOLD OUT!");
                    Console.WriteLine("---------");
                    Console.ResetColor();
                    Console.WriteLine();
                }


                //Can we do something fun here where if they try to buy without the money more than once, we return a warning?
                //Warning below ;)
                else if (slotCode.ToUpper() == product.SlotCode && CurrentBalance < product.Price)
                {
                    warnings++;

                    if (warnings > 1)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WARNING: Umbrella Corp DOES NOT tolerate dishonesty!");
                        Console.WriteLine("***your SSN has been submitted for a background check***");
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You DO NOT have enough money to purchase {product.BrandName}!");
                    Console.ResetColor();
                }


            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Money remaining in machine: ${CurrentBalance}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("____________________________________________");
            Console.WriteLine();
            Console.WriteLine("Would you like to buy something else? (Y\\N)");
            Console.WriteLine("____________________________________________");
            Console.ResetColor();


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Awaiting response...");
            Console.ResetColor();

            string buyMore = Console.ReadLine().ToUpper();

            if (buyMore == "Y")
            {
                SelectAndBuyItem();
            }

            else if (buyMore == "N")
            {
                PurchaseMenu();
            }

            SelectAndBuyItem();



        }



        //Return CHange
        public void FinishTransaction()
        {
            Console.Clear();
            ReturnChange(CurrentBalance);

            AmountBeforeAction = CurrentBalance;
            LogAction = "GIVE CHANGE:";



            Console.WriteLine("Don't forget your change!");
            Console.WriteLine($"Quarters: {Quarter}");
            Console.WriteLine($"Dimes: {Dime}");
            Console.WriteLine($"Nickels {Nickel}");


            Console.WriteLine();
            Console.WriteLine("Umbrella Corp thanks you for your monies.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------");
            Console.WriteLine("Return to Main Menu? (Y\\N)");
            Console.WriteLine("---------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Awaiting response...");
            Console.ResetColor();

            LogIt();

            string returnToMain = Console.ReadLine();


            if (returnToMain == "y" || returnToMain == "Y")
            {
                MainMenu();
            }

            else if (returnToMain == "n" || returnToMain == "N")
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }



        }


    }
}
