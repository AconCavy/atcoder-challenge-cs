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
            var n = int.Parse(Console.ReadLine());
            var answer = false;
            var cake = 0;
            while (n - 4 * cake >= 0)
            {
                var mod = n - 4 * cake;
                if (mod % 7 == 0)
                {
                    answer = true;
                    break;
                }
                cake++;
            }
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
