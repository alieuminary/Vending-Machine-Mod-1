using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Logger : VendingMachine
    {
        public string LogAction { get; set; }
        public double AmountBeforeAction { get; set; }
        public double AmountAfterAction { get; set; }


        public Logger()
        {


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

                string logLine = $"{now.Date} {LogAction} ${AmountBeforeAction} ${AmountAfterAction}";

                sw.WriteLine(logLine);
            }

        }





    }
}
