using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseCodeInvalidException : Exception
    {
        public PurchaseCodeInvalidException(string message) : base(message) { }
    }
}
