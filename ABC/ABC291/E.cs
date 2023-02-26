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
            var E = new HashSet<(int, int)>();
            var outDeg = new int[N];
            var inDeg = new int[N];

            for (var i = 0; i < M; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                x--; y--;
                if (E.Contains((x, y))) continue;
                E.Add((x, y));
                G[x].Add(y);
                outDeg[x]++;
                inDeg[y]++;
            }

            var queue = new Queue<int>();
            var deg = new int[N];
            inDeg.CopyTo(deg, 0);
            for (var i = 0; i < deg.Length; i++)
            {
                if (deg[i] == 0) queue.Enqueue(i);
            }

            var result = new int[N];
            var idx = 0;
            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                foreach (var v in G[u])
                {
                    deg[v]--;
                    if (deg[v] == 0) queue.Enqueue(v);
                }

                result[idx++] = u;
            }

            if (idx != N || outDeg.Count(x => x == 0) > 1 || inDeg.Count(x => x == 0) > 1)
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine("Yes");
            var answer = new int[N];
            for (var i = 0; i < N; i++)
            {
                answer[result[i]] = i + 1;
            }

            Console.WriteLine(string.Join(" ", answer));
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
