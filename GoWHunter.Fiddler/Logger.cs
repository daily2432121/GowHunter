using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWHunter.Fiddler
{
    public static class Logger
    {
        public static void LogConsoleAndDebug(string format, params object[] parameters)
        {
            string content = string.Format(format, parameters);
            Debug.WriteLine(content);
            System.Console.WriteLine(content);
        }
    }
}
