using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var (N, L) = Scanner.Scan<int, long>();
            var P = new List<(long X, char D)>();
            P.Add((0, 'R'));
            for (var i = 1; i <= N; i++)
            {
                var (x, d) = Scanner.Scan<long, char>();
                P.Add((x, d));
            }
            P.Add((L + 1, 'L'));

            var answer = 0L;
            for (var i = 0; i + 1 < P.Count; i++)
            {
                if (P[i].D != 'R' || P[i + 1].D != 'L') continue;
                var d = P[i + 1].X - P[i].X - 1;
                var (l, r) = (0L, 0L);
                var (ls, rs) = (0L, 0L);
                for (var j = i; j > 0 && P[j].D == 'R'; j--)
                {
                    ls += P[i].X - P[j].X - l;
                    l++;
                }

                for (var j = i + 1; j < P.Count - 1 && P[j].D == 'L'; j++)
                {
                    rs += P[j].X - P[i + 1].X - r;
                    r++;
                }

                answer += ls + rs + d * Math.Max(l, r);
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
