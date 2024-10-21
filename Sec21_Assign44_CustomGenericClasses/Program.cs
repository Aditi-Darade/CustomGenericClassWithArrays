using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sec21_Assign44_CustomGenericClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int ArraySize = 10;
            Database<int, int> d1 = new Database<int, int>();
            //d1.keys[0] = 1; 
            d1.Add(1,2);
            d1.Add(2,3);
            d1.Add(3,4);
            d1.Add(4,5);
            d1.Add(5,3);
            d1.Add(6,4);
            d1.Add(7,5);
            Console.WriteLine("--------------------");

            d1.Remove(3);            
            Console.WriteLine("--------------------");

            int i;
            d1.TryGetValue(1, out i);
            Console.WriteLine("--------------------");

            Console.WriteLine("Count: " + d1.Count());
            Console.WriteLine("--------------------");


            int a = 1;
            int b = 2;
            d1.Swap(ref a, ref b);

            Database<string, int> d2 = new Database<string, int>();
            string f = "Bill ";
            int g = 60;
            //d2.Swap(ref f, ref g);

            Database<string, string> d3 = new Database<string, string>();
            string r = "Bill ";
            string t = "Gates";
            d3.Swap<string>(ref r, ref t);


            Console.ReadKey();
        }
    }
}
