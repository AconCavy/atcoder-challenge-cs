using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var nq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var s = Console.ReadLine();
            var aggregate = new long[s.Length + 1];
            for (var i = 1; i < s.Length; i++)
            {
                aggregate[i + 1] = aggregate[i] + (s[i] == 'C' && s[i - 1] == 'A' ? 1 : 0);
            }
            for (var i = 0; i < nq[1]; i++)
            {
                var lr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var count = aggregate[lr[1]] - aggregate[lr[0]];
                Console.WriteLine(count);
            }
        }
    }
}
