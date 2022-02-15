using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Logger : VendingMachine
    {
        string LogAction {get; set;}
        double AmountBeforeAction { get; set; }
        double CurrentBalance { get; set; }



        public Logger()
        {

            CurrentBalance = base.CurrentBalance;

        }



        public void LogIt()
        {

            const string relativeFileName = @"..\..\..\..\Log.txt";
            string directory = Environment.CurrentDirectory;
            string filename = Path.Combine(directory, relativeFileName);
            string fullPath = Path.GetFullPath(filename);

            DateTime now = DateTime.Now;

            using (StreamWriter sw = File.AppendText(fullPath))
            {

                string logLine = $"{now.Date} {LogAction} ${AmountBeforeAction} ${CurrentBalance}";

                sw.WriteLine(logLine);
            }

        }





    }
}
