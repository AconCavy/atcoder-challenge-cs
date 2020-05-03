using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var x = long.Parse(Console.ReadLine());
            var a = 0;
            var b = 0;
            var a5 = Enumerable.Range(0, 10000).Select(x => new { X = (long)x, X5 = (long)Math.Pow(x, 5) }).ToArray();
            for (var i = 0; i < a5.Length; i++)
            {
                var b5 = a5[i].X5 - x;
                for (var j = 0; j < a5.Length; j++)
                {
                    if (Math.Abs(b5) == a5[j].X5)
                    {
                        a = i;
                        b = (b5 >= 0) ? j : -j;
                        break;
                    }
                }
            }
            Console.WriteLine($"{a} {b}");
        }
    }
}
