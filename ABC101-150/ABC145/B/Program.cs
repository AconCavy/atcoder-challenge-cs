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
            var s = Console.ReadLine();
            var result = n % 2 == 0;
            if (result) result = s.Substring(0, n / 2) == s.Substring(n / 2);
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
