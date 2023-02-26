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
            var S = new string[N];
            for (var i = 0; i < N; i++)
            {
                S[i] = Scanner.Scan<string>();
            }

            var dpS = new long[N];
            var dpT = new long[N];
            const long Inf = (long)1e18;
            Array.Fill(dpS, Inf);
            Array.Fill(dpT, Inf);
            dpS[0] = dpT[N - 1] = 0;
            for (var v = 1; v < N; v++)
            {
                for (var u = Math.Max(v - M, 0); u < v; u++)
                {
                    if (S[u][v - u - 1] == '1') dpS[v] = Math.Min(dpS[v], dpS[u] + 1);
                }
            }

            for (var v = N - 1; v > 0; v--)
            {
                for (var u = Math.Max(v - M, 0); u < v; u++)
                {
                    if (S[u][v - u - 1] == '1') dpT[u] = Math.Min(dpT[u], dpT[v] + 1);
                }
            }

            var answers = new List<long>(N - 2);
            for (var k = 1; k < N - 1; k++)
            {
                var answer = Inf;
                for (var u = Math.Max(k - M, 0); u < k; u++)
                {
                    for (var v = k + 1; v < Math.Min(u + M + 1, N); v++)
                    {
                        if (S[u][v - u - 1] == '1') answer = Math.Min(answer, dpS[u] + dpT[v] + 1);
                    }
                }

                answers.Add(answer == Inf ? -1 : answer);
            }

            Console.WriteLine(string.Join(" ", answers));
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
