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
            var n = int.Parse(Console.ReadLine());
            var list = new Dictionary<string, long>();
            for (var i = 0; i < n; i++)
            {
                var c = Console.ReadLine().ToCharArray();
                Array.Sort(c);
                var s = new string(c);
                if (list.ContainsKey(s)) list[s]++;
                else list.Add(s, 1);
            }
            var sum = 0L;
            foreach (var count in list.Values)
            {
                if (count > 1) sum += CombinationCount(count, 2);
            }
            Console.WriteLine(sum);
        }

        static long CombinationCount(long n, long k)
        {
            if (n < k) throw new ArgumentException();
            k = Math.Min(k, n - k);
            return PermutationCount(n, k) / PermutationCount(k, k);
        }

        static long PermutationCount(long n, long k)
        {
            if (n < k) throw new ArgumentException();
            var result = 1L;
            for (var i = 0; i < k; i++)
                result *= (n - i);
            return result;
        }
    }
}
