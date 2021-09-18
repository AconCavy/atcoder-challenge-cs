using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var S = Scanner.Scan<string>();
            var K = Scanner.Scan<long>();

            var hashset = new HashSet<(long X, long Y)>();
            var (cx, cy) = (0L, 0L);
            hashset.Add((cx, cy));
            foreach (var c in S)
            {
                switch (c)
                {
                    case 'L': cx--; break;
                    case 'R': cx++; break;
                    case 'U': cy--; break;
                    case 'D': cy++; break;
                }

                hashset.Add((cx, cy));
            }

            var V = hashset.ToArray();
            var N = V.Length;

            if (cx == 0 && cy == 0)
            {
                Console.WriteLine(N);
                return;
            }

            if (cx == 0)
            {
                (cx, cy) = (cy, cx);
                for (var i = 0; i < N; i++)
                {
                    var (x, y) = V[i];
                    V[i] = (y, x);
                }
            }

            if (cx < 0)
            {
                cx = -cx;
                for (var i = 0; i < N; i++)
                {
                    var (x, y) = V[i];
                    V[i] = (-x, y);
                }
            }

            var dict = new Dictionary<(long S, long T), List<long>>();
            foreach (var (x, y) in V)
            {
                var q = x / cx;
                var s = x - q * cx;
                if (s < 0)
                {
                    s += cx;
                    q--;
                }
                var t = y - q * cy;
                if (!dict.ContainsKey((s, t))) dict[(s, t)] = new List<long>();
                dict[(s, t)].Add(q);
            }

            var answer = 0L;
            foreach (var (_, q) in dict)
            {
                q.Sort();
                answer += K;
                for (var i = 0; i + 1 < q.Count; i++)
                {
                    var d = q[i + 1] - q[i];
                    answer += Math.Min(d, K);
                }
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
