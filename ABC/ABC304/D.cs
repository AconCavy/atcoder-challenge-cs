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
            var (W, H) = Scanner.Scan<int, int>();
            var N = Scanner.Scan<int>();
            var Berries = new (int X, int Y)[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                Berries[i] = (x, y);
            }

            var AN = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToList();
            var BN = Scanner.Scan<int>();
            var B = Scanner.ScanEnumerable<int>().ToList();
            A.Insert(0, 0);
            B.Insert(0, 0);

            var dict = new Dictionary<(int, int), int>();
            foreach (var (x, y) in Berries)
            {
                var i = LowerBound(A, x);
                var j = LowerBound(B, y);
                if (!dict.ContainsKey((i, j))) dict[(i, j)] = 0;
                dict[(i, j)]++;
            }

            const int Inf = (int)1e9;
            var min = Inf;
            var max = 0;
            foreach (var v in dict.Values)
            {
                min = Math.Min(min, v);
                max = Math.Max(max, v);
            }

            var ok = false;
            for (var i = 1; i <= AN + 1 && !ok; i++)
            {
                for (var j = 1; j <= BN + 1 && !ok; j++)
                {
                    if (!dict.ContainsKey((i, j)))
                    {
                        min = 0;
                        ok = true;
                    }
                }
            }

            Console.WriteLine($"{min} {max}");
        }

        public static int LowerBound<T>(List<T> source, T key) where T : IComparable<T>
        {
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (source[m].CompareTo(key) >= 0) r = m;
                else l = m;
            }
            return r;
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
