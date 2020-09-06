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
            var NMK = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var N = NMK[0];
            var M = NMK[1];
            var K = NMK[2];
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var B = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var cumA = CumulativeItems(A).ToArray();
            var cumB = CumulativeItems(B).ToArray();
            var answer = 0L;
            var j = M;
            for (var i = 0; i <= N; i++)
            {
                if (cumA[i] > K) break;
                while (cumB[j] > K - cumA[i]) j--;
                answer = Math.Max(answer, i + j);
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
