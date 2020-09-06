using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var abcd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var win = true;
            while (true)
            {
                abcd[2] -= abcd[1];
                if (abcd[2] <= 0) break;
                abcd[0] -= abcd[3];
                if (abcd[0] <= 0)
                {
                    win = false;
                    break;
                }

            }
            Console.WriteLine(win ? "Yes" : "No");
        }
    }
}
