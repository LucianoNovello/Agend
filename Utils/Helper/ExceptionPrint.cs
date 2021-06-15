using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ExceptionPrint
    {
        public static void Print(Exception e) {

            Console.WriteLine($"Message:{e.Message}");
            }
    }
}
