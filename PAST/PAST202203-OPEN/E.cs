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
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var S = Scanner.Scan<string>();
            var d = long.Parse(string.Join("", S.Split('/')));
            var N = 10;

            const int inf = (int)1e9;

            int F(int s, int a, int b)
            {
                var v = 0;
                for (var i = 0; i < 8; i++)
                {
                    v *= 10;
                    if ((s >> i & 1) == 0) v += a;
                    else v += b;
                }

                var month = GetMonth(v);
                var day = GetDay(v);
                if (month < 1 || month > 12) return inf;
                if (day < 1 || day > 31) return inf;

                return v;
            }

            int GetYear(int v) => v / 10000;
            int GetMonth(int v) => v / 100 % 100;
            int GetDay(int v) => v % 100;

            string Format(int v)
            {
                return $"{GetYear(v):00}/{GetMonth(v):00}/{GetDay(v):00}";
            }

            var min = 99999999;

            for (var a = 0; a < N; a++)
            {
                for (var b = a; b < N; b++)
                {
                    for (var s = 0; s < 1 << 8; s++)
                    {
                        var v = F(s, a, b);
                        if (v == inf) continue;
                        if (v >= d)
                        {
                            min = Math.Min(min, v);
                            // Console.WriteLine(Format(v));
                        }
                    }
                }
            }

            var answer = Format(min);
            Console.WriteLine(answer);
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
