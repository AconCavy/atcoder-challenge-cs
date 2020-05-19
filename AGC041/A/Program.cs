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
            var nab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            if ((nab[2] - nab[1]) % 2 == 0)
            {
                Console.WriteLine((nab[2] - nab[1]) / 2);
                return;
            }
            else
            {
                var left = nab[2] - 1;
                var right = nab[0] - nab[1];
                if (nab[1] == 1 || left <= right && nab[2] != nab[0])
                {
                    var tmp = nab[1];
                    Console.WriteLine(tmp + ((nab[2] - tmp) / 2));
                    return;
                }
                else
                {
                    var tmp = nab[0] - nab[2] + 1;
                    Console.WriteLine(tmp + ((nab[0] - (nab[1] + tmp)) / 2));
                    return;
                }
            }
        }
    }
}
