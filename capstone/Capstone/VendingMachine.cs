using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class VendingMachine
    {
        // properties & attributes

        public double Balance { get; set; }




        // ========================= CONSTRUCTOR ================= //
        //public VendingMachine(double balance)
        //{
        //    this.Balance = balance;
        //}


        // ========================= METHODS ===================== //

        // customer inserts money into vending machine
        public void FeedMoney(int amountOfMoney)
        {
            this.Balance += amountOfMoney;
        }
    }
}
