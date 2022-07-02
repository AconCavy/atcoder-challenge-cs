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
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, Q, X) = Scanner.Scan<int, int, long>();
            var W = Scanner.ScanEnumerable<long>().ToArray();
            var sum = W.Sum();

            var cumW = new long[N * 2 + 1];
            for (var i = 0; i < N * 2; i++)
            {
                cumW[i + 1] = cumW[i] + W[i % N];
            }

            var counts = new long[N];
            {
                var r = 0;
                var x = X % sum;
                for (var l = 0; l < N; l++)
                {
                    counts[l] = X / sum * N;
                    while (cumW[r] - cumW[l] < x) r++;
                    counts[l] += r - l;
                }
            }

            var next = new int[N];
            for (var i = 0; i < N; i++)
            {
                next[i] = (int)((i + counts[i]) % N);
            }

            var steps = new List<int>();
            var dict = new Dictionary<int, int>();
            var noLoopLength = 0;
            var loopLength = 0;
            {
                var curr = 0;
                for (var i = 0; ; i++)
                {
                    if (dict.ContainsKey(curr))
                    {
                        noLoopLength = dict[curr];
                        loopLength = i - dict[curr];
                        break;
                    }

                    dict[curr] = i;
                    steps.Add(curr);
                    curr = next[curr];
                }
            }

            while (Q-- > 0)
            {
                var K = Scanner.Scan<long>() - 1;
                if (K <= noLoopLength)
                {
                    var box = steps[(int)K];
                    Console.WriteLine(counts[box]);
                }
                else
                {
                    var mod = (K - noLoopLength) % loopLength;
                    var box = steps[(int)(noLoopLength + mod)];
                    Console.WriteLine(counts[box]);
                }
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
