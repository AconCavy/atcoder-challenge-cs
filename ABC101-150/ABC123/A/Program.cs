using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var x = new int[5];
            for (var i = 0; i < x.Length; i++)
            {
                x[i] = int.Parse(Console.ReadLine());
            }
            var k = int.Parse(Console.ReadLine());
            var isOk = true;

            for (var i = 0; i < x.Length - 1; i++)
            {
                for (var j = i + 1; j < x.Length; j++)
                {
                    if (Math.Abs(x[i] - x[j]) > k)
                    {
                        isOk = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isOk ? "Yay!" : ":(");
        }
    }
}
