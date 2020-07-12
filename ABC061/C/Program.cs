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
            var NK = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (N, K) = (NK[0], NK[1]);
            var dict = new Dictionary<long, long>();
            for (var i = 0; i < N; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                var (a, b) = (ab[0], ab[1]);
                if (dict.ContainsKey(a)) dict[a] += b;
                else dict[a] = b;
            }
            var count = 0L;
            foreach (var val in dict.Keys.OrderBy(x => x).ToArray())
            {
                count += dict[val];
                if (count >= K)
                {
                    Console.WriteLine(val);
                    return;
                }
            }
        }
    }
}
