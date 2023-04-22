using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var (N, M) = Scanner.Scan<int, int>();

            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                G[u].Add(v);
                G[v].Add(u);
            }

            var K = Scanner.Scan<int>();
            if (K == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(new string('1', N));
                return;
            }

            var D = new int[N][];
            var queue = new Queue<int>();
            for (var i = 0; i < N; i++)
            {
                var dist = new int[N];
                Array.Fill(dist, -1);
                queue.Enqueue(i);
                dist[i] = 0;
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

                D[i] = dist;
            }

            var minD = new int[N];
            const int Inf = (int)1e9;
            Array.Fill(minD, Inf);
            for (var i = 0; i < K; i++)
            {
                var (p, d) = Scanner.Scan<int, int>();
                p--;
                minD[p] = d;
            }

            var C = new int[N];
            Array.Fill(C, 1);
            for (var i = 0; i < N; i++)
            {
                if (minD[i] == Inf) continue;
                for (var j = 0; j < N; j++)
                {
                    if (minD[i] > D[i][j])
                    {
                        C[j] = 0;
                    }
                }
            }

            for (var i = 0; i < N; i++)
            {
                if (minD[i] == Inf) continue;
                var ok = false;
                for (var j = 0; j < N; j++)
                {
                    if (C[j] == 1 && minD[i] == D[i][j])
                    {
                        ok = true;
                    }
                }

                if (!ok)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            if (!C.Contains(1))
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine("Yes");
            Console.WriteLine(string.Join("", C));
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
