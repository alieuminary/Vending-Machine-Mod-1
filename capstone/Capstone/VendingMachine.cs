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
        public void StockTheMachine()
        {
            string stockFile = "vendingmachine.csv";
            string directory = @"C:\Users\Student\Desktop\Umbrell Corp Vending 1.0001\capstone";
            string fullPath = Path.Combine(directory, stockFile);



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
                    Console.WriteLine("products"); // PurchaseMenu
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




        public void SelectAndBuyItem()
        {


            //Display Products
            foreach (Product product in Stock)
            {
                Console.WriteLine("CODE: " + product.SlotCode + " || " + product.BrandName + "Price: " + product.Price);
            }


            //Select Product
            Console.WriteLine("Please choose a product by typing it's CODE");

            string slotCode = Console.ReadLine();


            //Buy Product
            foreach (Product product in Stock)
            {
                if (slotCode == product.SlotCode)
                {
                    SpendMoney(product.Price);
                    product.Supply -= 1;
                }
            }

        }




    }
}
