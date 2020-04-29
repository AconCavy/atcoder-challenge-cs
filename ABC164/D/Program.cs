using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var s = Console.ReadLine();
            var mod = 2019;
            var counts = new long[mod];
            var aggregate = 0;
            var digit = 1;
            var count = 0L;
            counts[aggregate]++;
            for (var i = 0; i < s.Length; i++)
            {
                aggregate = (aggregate + (s[s.Length - 1 - i] - '0') * digit) % mod;
                counts[aggregate]++;
                digit = (digit * 10) % mod;
            }
            for (var i = 0; i < counts.Length; i++)
            {
                count += (counts[i] * (counts[i] - 1)) / 2;
            }
            Console.WriteLine(count);
        }
    }
}
