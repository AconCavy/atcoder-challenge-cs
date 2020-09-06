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
            var k = int.Parse(Console.ReadLine());
            var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var isOk = false;
            for (var i = ab[0]; i <= ab[1]; i++)
            {
                if (i % k == 0)
                {
                    isOk = true;
                    break;
                }
            }
            Console.WriteLine(isOk ? "OK" : "NG");
        }
    }
}
