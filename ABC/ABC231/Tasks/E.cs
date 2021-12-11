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
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, X) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();

            const long inf = (long)1e18;
            var dp1 = new Dictionary<long, long>();
            dp1[X] = 0;
            for (var i = N - 1; i >= 0; i--)
            {
                var dp2 = new Dictionary<long, long>();
                foreach (var (x, c) in dp1)
                {
                    var ceil = (x + A[i] - 1) / A[i];
                    var a = Math.Abs(x - ceil * A[i]);
                    if (!dp2.ContainsKey(a)) dp2[a] = inf;
                    dp2[a] = Math.Min(dp2[a], c + ceil);

                    var floor = x / A[i];
                    var b = Math.Abs(x - floor * A[i]);
                    if (!dp2.ContainsKey(b)) dp2[b] = inf;
                    dp2[b] = Math.Min(dp2[b], c + floor);
                }

                dp1 = dp2;
            }

            var answer = dp1[0];
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
