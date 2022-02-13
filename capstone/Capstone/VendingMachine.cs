using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    class VendingMachine
    {
        // properties & attributes

        public double CurrentBalance { get; set; }
        public double TotalSpent { get; set; }

        List<Product> Stock = new List<Product>();


        // ========================= CONSTRUCTOR ================= //
        //public VendingMachine(double balance)
        //{
        //    this.Balance = balance;
        //}


        // ========================= METHODS ===================== //

        // customer inserts money into vending machine



        //Stock Method
        public void StockTheMachine() // Needs to be relative
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



        ///Financial Methods
        public void FeedMoney(int amountOfMoney)
        {
            this.CurrentBalance += amountOfMoney;
        }
        public void SpendMoney(double price)
        {
            CurrentBalance -= price;
        }


        //Display Methods

        public void MainMenu()
        {

            Console.Clear();

            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");

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

            foreach (Product product in Stock)
            {
                Console.WriteLine(product.BrandName + " " + product.SlotCode);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("(1) Return To Main Menu");
            Console.WriteLine("-----------------------");
            string returnToMain = Console.ReadLine();

            if (returnToMain == "1")
            {
                MainMenu();
            }

            DisplayItems();
        }

        public void PurchaseMenu()
        {

            Console.Clear();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");

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

            Console.WriteLine("(1) Insert $1");
            Console.WriteLine("(2) Insert $2");
            Console.WriteLine("(3) Insert $5");
            Console.WriteLine("(4) Insert $10");

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
            Console.WriteLine("Do you want to add more money? (Y\\N)");
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

            //Display Products
            foreach (Product product in Stock)
            {
                Console.WriteLine("CODE: " + product.SlotCode + " || " + product.BrandName + ": $" + product.Price);
            }


            //Select Product
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Please choose a product by typing it's CODE");
            Console.WriteLine("-------------------------------------------");


            string slotCode = Console.ReadLine();


            //Buy Product
            foreach (Product product in Stock)
            {
                if (slotCode == product.SlotCode && product.Supply > 0)
                {
                    SpendMoney(product.Price);
                    product.Supply -= 1;
                    TotalSpent += product.Price;

                    Console.WriteLine();
                    Console.WriteLine($"Please retrieve your {product.BrandName} from the tray... {product.Message}");
                    Console.WriteLine();
                }

                else if (slotCode == product.SlotCode && product.Supply == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------");
                    Console.WriteLine("SOLD OUT!");
                    Console.WriteLine("---------");
                    Console.WriteLine();
                }

            }

            Console.WriteLine($"Money remaining in machine: ${CurrentBalance}");
            Console.WriteLine();
            Console.WriteLine("Would you like to buy something else? (Y\\N)");
            Console.WriteLine();
            Console.WriteLine("Awaiting response...");

            string buyMore = Console.ReadLine();

            if (buyMore == "y" || buyMore == "Y")
            {
                SelectAndBuyItem();
            }

            else if (buyMore == "n" || buyMore == "N")
            {
                PurchaseMenu();
            }

            SelectAndBuyItem();



        }




        //Return Change
        public void FinishTransaction()
        {
            double changeToReturn = CurrentBalance * 100;
            double quarters = (int)(changeToReturn / 25);

            changeToReturn -= (quarters * 25);

            double dimes = (int)(changeToReturn / 10);

            changeToReturn -= (dimes * 10);

            double nickels = (int)(changeToReturn / 5);


            Console.WriteLine("Don't forget your change!");
            Console.WriteLine($"Quarters: {quarters} Dimes: {dimes} Nickels: {nickels}");

            CurrentBalance = 0;
            Console.WriteLine();
            Console.WriteLine("Umbrella Corp thanks you for your monies.");
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Return to Main Menu? (Y\\N)");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine("Awaiting response...");

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
