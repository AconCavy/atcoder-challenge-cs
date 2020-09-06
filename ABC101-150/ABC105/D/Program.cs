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
            var nm = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var m = nm[1];
            var answer = 0L;
            var dict = new Dictionary<long, long>();
            dict[0] = 1;
            var aggregate = 0L;

            for (var i = 0; i < ai.Length; i++)
            {
                aggregate += ai[i];
                var tmp = aggregate % m;
                dict[tmp] = dict.ContainsKey(tmp) ? dict[tmp] + 1 : 1;
            }

            foreach (var count in dict.Values) answer += count * (count - 1);
            Console.WriteLine(answer / 2);
        }
    }
}
