using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class DisplayServices
    {
        public string MenuSelect1 { get;  }
        public string MenuSelect2 { get; }
        public string MenuSelect3 { get; }
        public string HiddenMenu { get; }


        public DisplayServices(string menuSelect1, string menuSelect2, string menuSelect3, string hiddenMenu)
        {
            MenuSelect1 = menuSelect1;
            MenuSelect2 = menuSelect2;
            MenuSelect3 = menuSelect3;
            HiddenMenu = hiddenMenu;
        }


    }
}
