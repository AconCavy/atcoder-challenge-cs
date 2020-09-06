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
            var li = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var max = li.Max();
            var sum = li.Sum();
            Console.WriteLine(sum - max > max ? "Yes" : "No");
        }
    }
}
