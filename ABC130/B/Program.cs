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
            var nx = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var li = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var count = 1;
            var current = 0L;
            for (var i = 0; i < li.Length; i++)
            {
                current += li[i];
                if (current <= nx[1]) count++;
                else break;
            }
            Console.WriteLine(count);
        }
    }
}
