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
            var N = Scanner.Scan<int>();
            var P = new (int R, int C, long X)[N];
            var rx = new Dictionary<int, long>();
            var cx = new Dictionary<int, long>();
            var X = new Dictionary<(int R, int C), long>();

            for (var i = 0; i < N; i++)
            {
                var (r, c, x) = Scanner.Scan<int, int, long>();
                P[i] = (r, c, x);
                if (!rx.ContainsKey(r)) rx[r] = 0;
                if (!cx.ContainsKey(c)) cx[c] = 0;
                rx[r] += x;
                cx[c] += x;
                X[(r, c)] = x;
            }

            long answer = 0;
            var rx2 = rx.OrderByDescending(x => x.Value).Take(2).ToArray();
            var cx2 = cx.OrderByDescending(x => x.Value).Take(2).ToArray();

            foreach (var (r, rs) in rx)
            {
                foreach (var (c, cs) in cx2)
                {
                    var v = rs + cs;
                    if (X.ContainsKey((r, c))) v -= X[(r, c)];
                    answer = Math.Max(answer, v);
                }
            }

            foreach (var (c, cs) in cx)
            {
                foreach (var (r, rs) in rx2)
                {
                    var v = rs + cs;
                    if (X.ContainsKey((r, c))) v -= X[(r, c)];
                    answer = Math.Max(answer, v);
                }
            }

            Console.WriteLine(answer);
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
