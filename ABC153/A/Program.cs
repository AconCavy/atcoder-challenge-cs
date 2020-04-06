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
            var ha = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var mod = ha[0] % ha[1];
            var div = ha[0] / ha[1];
            Console.WriteLine(mod > 0 ? div + 1 : div);
        }
    }
}
