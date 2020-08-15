using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var (N, K) = Scanner.Scan<int, int>();
            var P = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x) - 1).ToArray();
            var C = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = -(long)1e18;

            for (var start = 0; start < N; start++)
            {
                var x = start;
                var cycle = new List<long>();
                var sum = 0L;
                while (true)
                {
                    x = P[x];
                    cycle.Add(C[x]);
                    sum += C[x];
                    if (x == start) break;
                }
                var tmp = 0L;
                for (var i = 0; i < cycle.Count; i++)
                {
                    tmp += cycle[i];
                    if (i + 1 > K) break;
                    var current = tmp;
                    if (sum > 0)
                    {
                        var e = (K - i - 1) / cycle.Count;
                        current += sum * e;
                    }
                    answer = Math.Max(answer, current);
                }
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
        }
    }
}
