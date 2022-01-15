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
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (A, N) = Scanner.Scan<long, long>();
            var dp = new Dictionary<long, int>();
            dp[1] = 0;

            var queue = new Queue<long>();
            queue.Enqueue(1);
            const int inf = (int)1e7;

            void Push(long curr, long next)
            {
                if (next > inf) return;
                if (dp.ContainsKey(next)) return;
                dp[next] = dp[curr] + 1;
                queue.Enqueue(next);
            }

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                if (u >= 10 && u % 10 != 0)
                {
                    var v = long.Parse(Shift(u.ToString().AsSpan(), 1));
                    Push(u, v);
                }
                Push(u, u * A);
            }

            if (dp.ContainsKey(N))
            {
                Console.WriteLine(dp[N]);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        public static T[] Shift<T>(ReadOnlySpan<T> source, int shift)
        {
            shift = (shift + source.Length) % source.Length;
            if (shift == 0) return source.ToArray();
            var result = new T[source.Length];
            source[^shift..].CopyTo(result.AsSpan(..shift));
            source[..^shift].CopyTo(result.AsSpan(shift..));
            return result;
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
