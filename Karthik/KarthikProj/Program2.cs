using System;
using System.Collections.Generic;
using System.Text;

namespace KarthikProj
{
    delegate void Printer(String toP);
    class Program2
    {
        Printer P = printV;

        
        
        //concrete implementation of delegate
        public static void printV(String intake)
        {
            Console.WriteLine($" value undertaken is : {intake}");//C# 6 feature "String interpolation" instead of using + as concatenation
        }
       
    }
}
