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

        public string MainMenuNav(string selection)
        {

            Console.WriteLine(base.MenuSelect1);
            Console.WriteLine(base.MenuSelect2);
            Console.WriteLine(base.MenuSelect3);



            string userInput = Console.ReadLine();
            return userInput;
        }



    }
}
