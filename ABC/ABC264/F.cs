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
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W) = Scanner.Scan<int, int>();
            var R = Scanner.ScanEnumerable<long>().ToArray();
            var C = Scanner.ScanEnumerable<long>().ToArray();
            var A = new int[H][];
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.ScanLine().Select(x => x - '0').ToArray();
            }

            const long Inf = (long)1e18;
            var dp = new long[H, W, 4, 2];
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    for (var k = 0; k < 4; k++)
                    {
                        dp[i, j, k, 0] = dp[i, j, k, 1] = Inf;
                    }
                }
            }

            dp[0, 0, 0, A[0][0]] = 0;
            dp[0, 0, 1, A[0][0] ^ 1] = R[0];
            dp[0, 0, 2, A[0][0] ^ 1] = C[0];
            dp[0, 0, 3, A[0][0]] = R[0] + C[0];

            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    for (var k = 0; k < 4; k++)
                    {
                    }
                }
            }

            var answer = Inf;
            for (var k = 0; k < 4; k++)
            {
                answer = Math.Min(answer, dp[H - 1, W - 1, k, 0]);
                answer = Math.Min(answer, dp[H - 1, W - 1, k, 1]);
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
