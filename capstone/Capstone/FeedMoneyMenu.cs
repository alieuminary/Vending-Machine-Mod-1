using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class FeedMoneyMenu : DisplayServices
    {
        public int UserMoney = 0;
        public FeedMoneyMenu() : base("(1) Insert $1", "(2) Insert $5", "(3) Insert $10", " ")
        {
         

        }
        
        public void FeedMoneyMenuNav()
        {

            Console.WriteLine("Please select an amount to deposit");
            Console.WriteLine(base.MenuSelect1);
            Console.WriteLine(base.MenuSelect2);
            Console.WriteLine(base.MenuSelect3);

            string moneyInserted = Console.ReadLine();
            

            if (moneyInserted == "1")
            {
                UserMoney += 1;
            }

            else if (moneyInserted == "2")
            {
                UserMoney += 5;
            }

            else if (moneyInserted == "3")
            {
                UserMoney += 10;
            }

            Console.WriteLine($"You currently have ${UserMoney} to spend... Choose wisely.");
            
            Console.WriteLine("Add More Money? (Y\\N)");

            string addMoreMoney = Console.ReadLine();

            if(addMoreMoney == "y" || addMoreMoney == "Y")
            {
                FeedMoneyMenuNav();
            }

            if(addMoreMoney == "n" || addMoreMoney == "N")
            {
                var purchaseMenu = new PurchaseMenu();
                purchaseMenu.PurchaseMenuNav();
            }

        }


    }
}
