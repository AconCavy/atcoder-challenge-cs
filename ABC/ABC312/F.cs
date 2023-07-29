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
            var cans0 = new List<long>();
            var cans1 = new List<long>();
            var openers = new List<int>();
            for (var i = 0; i < N; i++)
            {
                var (T, X) = Scanner.Scan<int, int>();
                if (T == 0)
                {
                    cans0.Add(X);
                }
                else if (T == 1)
                {
                    cans1.Add(X);
                }
                else
                {
                    openers.Add(X);
                }
            }

            cans0.Sort();
            cans0.Reverse();
            cans1.Sort();
            cans1.Reverse();
            openers.Sort();
            openers.Reverse();
            var N0 = cans0.Count;
            var N1 = cans1.Count;
            var N2 = openers.Count;

            var cum0 = new long[M + 1];
            for (var i = 0; i < M; i++)
            {
                cum0[i + 1] = cum0[i];
                if (i < N0) cum0[i + 1] += cans0[i];
            }

            var cum1 = new long[M + 1];
            {
                var i = 0;
                var j = 0;
                var rem = 0;
                for (var k = 0; k < M; k++)
                {
                    cum1[k + 1] += cum1[k];
                    if (rem > 0 && i < N1)
                    {
                        cum1[k + 1] += cans1[i++];
                        rem--;
                    }
                    else if (j < N2)
                    {
                        rem = openers[j++];
                    }
                }
            }

            long answer = 0;
            for (var i = 0; i <= M; i++)
            {
                answer = Math.Max(answer, cum0[i] + cum1[M - i]);
            }

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
