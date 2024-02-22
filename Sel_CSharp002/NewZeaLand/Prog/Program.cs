using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewZeaLand.Prog
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.Write("Hello Automation tester!");
            
            List<int> lst = new List<int>() { 1,4, 3, 44, 5, 56, 18 };
            List<int> lst2 = new List<int>() {  };
            var fst=lst.FirstOrDefault();
            var second = lst2.FirstOrDefault();
            Console.WriteLine("First:Second "+fst+" : "+second);

            //Distinct
            var uniq=lst.Distinct().ToList() ;
            //Filter 
            var lstEven=lst.Where(x => x % 2 == 0).ToList(); 
            //Order by ASC
            var lstAsc=lst.OrderBy(x=>x).ToList();
            //Order by DESC
            var lstDesc = lst.OrderByDescending(x => x).ToList();
            //CheckEven [ any one]
            var checkEven=lst.Any(x => x % 2 == 0);
            //CheckEvn
            var checkAllForEven=lst.All(x => x % 2 == 0);
            string str = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            string randomStr=new String(Enumerable.Repeat(str, 10).Select(x => x[rand.Next(0, str.Length)]).ToArray());
            Console.WriteLine(randomStr);
            Console.Read();
        }
    }
}
