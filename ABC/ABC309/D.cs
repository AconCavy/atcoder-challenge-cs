using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
    {
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N1, N2, M) = Scanner.Scan<int, int, int>();
            var G1 = new List<int>[N1].Select(x => new List<int>()).ToArray();
            var G2 = new List<int>[N2].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                if (a < N1)
                {
                    G1[a].Add(b);
                    G1[b].Add(a);
                }
                else
                {
                    a -= N1;
                    b -= N1;
                    G2[a].Add(b);
                    G2[b].Add(a);
                }
            }

            int MaxDist(List<int>[] G, int N, int s)
            {
                var dist = new int[N];
                Array.Fill(dist, -1);
                var queue = new Queue<int>();
                queue.Enqueue(s);
                dist[s] = 0;
                while (queue.Count > 0)
                {
                    var u = queue.Dequeue();
                    foreach (var v in G[u])
                    {
                        if (dist[v] != -1) continue;
                        dist[v] = dist[u] + 1;
                        queue.Enqueue(v);
                    }
                }

                return dist.Max();
            }

            var answer = MaxDist(G1, N1, 0) + MaxDist(G2, N2, N2 - 1) + 1;
            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var input = ScanStringArray();
                return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
            private static string[] ScanStringArray()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
