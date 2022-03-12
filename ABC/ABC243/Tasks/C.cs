using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var N = Scanner.Scan<int>();
            var P = new (int X, int Y)[N];
            for (var i = 0; i < N; i++)
            {
                P[i] = Scanner.Scan<int, int>();
            }

            var S = Scanner.Scan<string>();
            var L = new Dictionary<int, List<int>>();
            var R = new Dictionary<int, List<int>>();
            for (var i = 0; i < N; i++)
            {
                var (x, y) = P[i];
                if (S[i] == 'L')
                {
                    if (!L.ContainsKey(y)) L[y] = new List<int>();
                    L[y].Add(x);
                }
                else
                {
                    if (!R.ContainsKey(y)) R[y] = new List<int>();
                    R[y].Add(x);
                }
            }

            foreach (var (_, v) in L) v.Sort();
            foreach (var (_, v) in R) v.Sort();

            foreach (var (k, list) in R)
            {
                if (!L.ContainsKey(k)) continue;
                foreach (var x1 in R[k])
                {
                    var lb = LowerBound(L[k], x1);
                    if (lb < L[k].Count && x1 <= L[k][lb])
                    {
                        Console.WriteLine("Yes");
                        return;
                    }

                }
            }

            Console.WriteLine("No");
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
