using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var dict = new Dictionary<int, int>();
            var is5 = 0;
            var is7 = 0;
            foreach (var x in ABC)
            {
                if (x == 5) is5++;
                if (x == 7) is7++;
            }
            Console.WriteLine(is5 == 2 && is7 == 1 ? "YES" : "NO");
        }
    }
}
