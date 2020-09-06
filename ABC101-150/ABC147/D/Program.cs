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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var p = (long)Math.Pow(10, 9) + 7;
            var result = 0L;
            for (var bit = 0; bit < 60; bit++)
            {
                var num = 0L;
                foreach (var a in ai) if ((a >> bit & 1) == 1) num++;
                var mul0x1 = ((ai.Length - num) * num) % p;
                for (var i = 0; i < bit; i++) mul0x1 = mul0x1 * 2 % p;
                result += (mul0x1 % p);
            }
            Console.WriteLine(result % p);
        }
    }
}
