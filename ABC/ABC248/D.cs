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
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var dict = new Dictionary<int, List<int>>();
            for (var i = 0; i < N; i++)
            {
                var a = A[i];
                if (!dict.ContainsKey(a)) dict[a] = new List<int>();
                dict[a].Add(i);
            }

            var Q = Scanner.Scan<int>();
            while (Q-- > 0)
            {
                var (L, R, X) = Scanner.Scan<int, int, int>();
                L--; R--;
                if (dict.ContainsKey(X))
                {
                    var list = dict[X];
                    var l = LowerBound(list, L);
                    var r = UpperBound(list, R);
                    Console.WriteLine(r - l);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
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

        public static int UpperBound<T>(List<T> source, T key) where T : IComparable<T>
        {
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (source[m].CompareTo(key) > 0) r = m;
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
