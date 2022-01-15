using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
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
            const long Mod = 998244353;
            var V = Console.ReadLine().Trim();
            var N = V.Length;
            var M = Scanner.Scan<int>();
            var C = Console.ReadLine().Trim().Split(' ');

            var ok = 0;
            foreach (var c in C)
            {
                ok |= 1 << int.Parse(c);
            }

            var max = 1 << 10;
            var count = new long[2][] { new long[max], new long[max] };
            var sum = new long[2][] { new long[max], new long[max] };
            long curr = 0;
            var digit = 0;

            var t = 1;
            for (var i = 0; i < N; i++)
            {
                t ^= 1;
                var tt = t ^ 1;
                var c = V[i] - '0';
                Array.Fill(count[tt], 0);
                Array.Fill(sum[tt], 0);
                for (var j = 0; j < max; j++)
                {
                    for (var d = 0; d < 10; d++)
                    {
                        var next = j | (1 << d);
                        count[tt][next] += count[t][j];
                        count[tt][next] %= Mod;
                        sum[tt][next] += sum[t][j] * 10 + count[t][j] * d;
                        sum[tt][next] %= Mod;
                    }
                }

                if (i > 0)
                {
                    for (var d = 1; d < 10; d++)
                    {
                        var next = 1 << d;
                        count[tt][next]++;
                        count[tt][next] %= Mod;
                        sum[tt][next] += d;
                        sum[tt][next] %= Mod;
                    }
                }

                for (var d = 0; d < c; d++)
                {
                    if (i == 0 && d == 0) continue;
                    var next = digit | (1 << d);
                    count[tt][next]++;
                    count[tt][next] %= Mod;
                    sum[tt][next] += curr * 10 + d;
                    sum[tt][next] %= Mod;
                }

                digit |= 1 << c;
                curr = (curr * 10 + c) % Mod;
            }

            t ^= 1;
            var answer = 0L;
            for (var j = 0; j < max; j++)
            {
                if ((j & ok) == ok)
                {
                    answer += sum[t][j];
                    answer %= Mod;
                }
            }

            if ((digit & ok) == ok)
            {
                answer += curr;
                answer %= Mod;
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(ScanLine()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = ScanLine();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanLine().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
            private static string[] ScanLine() => Console.ReadLine()?.Trim().Split(' ') ?? Array.Empty<string>();
        }
    }
}
