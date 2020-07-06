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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var agg = CumulativeItems(A).ToArray();
            var answer = (long)2 * 1e9 + 1;
            for (var i = 1; i < agg.Length - 1; i++)
            {
                var x = agg[i] - agg[0];
                var y = agg[agg.Length - 1] - agg[i];
                answer = Math.Min(answer, Math.Abs(x - y));
            }
            Console.WriteLine(answer);
        }

        public static IEnumerable<long> CumulativeItems(IEnumerable<long> items)
        {
            var arr = items.ToArray();
            var ret = new long[arr.Length + 1];
            for (var i = 0; i < arr.Length; i++) ret[i + 1] = arr[i] + ret[i];
            return ret;
        }
    }
}
