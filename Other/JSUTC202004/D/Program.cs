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
            var nq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var si = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            for (var i = 0; i < nq[1]; i++)
            {
                var x = si[i];
                var index = nq[0];
                for (var j = 0; j < nq[0]; j++)
                {
                    x = GCD(x, ai[j]);
                    if (x == 1)
                    {
                        index = j + 1;
                        break;
                    }
                }
                Console.WriteLine(x == 1 ? index : x);
            }

        }

        static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
