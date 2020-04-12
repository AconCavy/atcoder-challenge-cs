using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var sum = 0L;
            for (var a = 1; a <= k; a++)
            {
                for (var b = 1; b <= k; b++)
                {
                    var tmp = GCD(a, b);
                    for (var c = 1; c <= k; c++)
                    {
                        sum += GCD(tmp, c);
                    }
                }
            }
            Console.WriteLine(sum);
        }

        static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
