using System;
using System.Collections.Generic;
using System.IO;


namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            VendingMachine Machine = new VendingMachine();

            Machine.StockTheMachine();

            Machine.MainMenu();



        }
    }
}

