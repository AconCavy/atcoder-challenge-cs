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
        public static void Main()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H1, W1) = Scanner.Scan<int, int>();
            var A = new int[H1][];
            for (var i = 0; i < H1; i++)
            {
                A[i] = Scanner.ScanEnumerable<int>().ToArray();
            }

            var (H2, W2) = Scanner.Scan<int, int>();
            var B = new int[H2][];
            for (var i = 0; i < H2; i++)
            {
                B[i] = Scanner.ScanEnumerable<int>().ToArray();
            }

            for (var H = 0; H < 1 << H1; H++)
            {
                var hc = 0;
                for (var k = 0; k < H1; k++)
                {
                    if ((H >> k & 1) == 1) hc++;
                }
                if (hc != H2) continue;

                for (var W = 0; W < 1 << W1; W++)
                {
                    var wc = 0;
                    for (var k = 0; k < W1; k++)
                    {
                        if ((W >> k & 1) == 1) wc++;
                    }

                    if (wc != W2) continue;

                    var G = new List<List<int>>();
                    for (var i = 0; i < H1; i++)
                    {
                        if ((H >> i & 1) == 1) G.Add(new List<int>());
                        else continue;

                        for (var j = 0; j < W1; j++)
                        {
                            if ((W >> j & 1) == 1) G[^1].Add(A[i][j]);
                        }
                    }

                    var ok = true;
                    for (var i = 0; i < H2; i++)
                    {
                        for (var j = 0; j < W2; j++)
                        {
                            ok &= G[i][j] == B[i][j];
                        }
                    }

                    if (ok)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }

            Console.WriteLine("No");
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
