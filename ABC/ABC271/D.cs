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
            var (N, S) = Scanner.Scan<int, int>();
            var dp = new bool[N + 1, S + 1, 2];
            var prev = new (int, int)[N + 1, S + 1, 2];
            dp[0, 0, 0] = dp[0, 0, 1] = true;
            // prev[0, 0, 0] = prev[0, 0, 1] = (-1, -1);

            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                for (var j = 0; j <= S; j++)
                {
                    if (j + a <= S)
                    {
                        for (var k = 0; k < 2; k++)
                        {
                            if (dp[i, j, k])
                            {
                                dp[i + 1, j + a, 0] |= dp[i, j, k];
                                prev[i + 1, j + a, 0] = (j, k);
                            }
                        }
                    }

                    if (j + b <= S)
                    {
                        for (var k = 0; k < 2; k++)
                        {
                            if (dp[i, j, k])
                            {
                                dp[i + 1, j + b, 1] |= dp[i, j, k];
                                prev[i + 1, j + b, 1] = (j, k);
                            }
                        }
                    }
                }
            }

            if (dp[N, S, 0] || dp[N, S, 1])
            {
                var list = new List<int>();
                var curr = dp[N, S, 0] ? (S, 0) : (S, 1);
                for (var i = N; i > 0; i--)
                {
                    list.Add(curr.Item2);
                    curr = prev[i, curr.Item1, curr.Item2];
                }
                list.Reverse();
                var answer = string.Join("", list.Select(x => x == 0 ? 'H' : 'T'));
                Console.WriteLine("Yes");
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine("No");
            }
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
