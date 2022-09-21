/*laboratory work 03
 Marchuk Bogdan IO-04
 Variant :      1.12 A = B + C + D(MD*ME)
                2.23 q = MAX(MH*MK-ML)
                3.28 s = MAX(S*MO) + MIN(MT*MS + MP)
 */
using System;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Threading;
using Data;

namespace parallel_programming
{
    public class Program
    {
        public static int N { get; set; }
        public static bool Key { get; set; }

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Perform data entry automatically (Y/N):");
                string key = Console.ReadLine();
                
                if (key.ToLower()[0] == 'y') { Key = true; }
                else if (key.ToLower()[0] == 'n') { Key = false; }
                else
                {
                    Console.WriteLine("Invalid value entered");
                    continue;
                }
                break;
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter dimensionality for matrices and vectors:");
                    N = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e) { Console.WriteLine("Invalid value entered"); }   
            }
            
            Functions func = new Functions();
            Thread F1 = new Thread(func.Func1) { Priority = ThreadPriority.Highest, Name = "F1" };
            Thread F2 = new Thread(func.Func2) { Priority = ThreadPriority.Highest, Name = "F2"};
            Thread F3 = new Thread(func.Func3) { Priority = ThreadPriority.Highest, Name = "F3"};
            F1.Start();
            F2.Start();
            F3.Start();

        }
    }
}