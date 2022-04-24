using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var T = Scanner.ScanEnumerable<int>().ToArray();

            // int Ctz(ulong x)
            // {
            //     var result = 0;
            //     while ((x & 1) == 0)
            //     {
            //         result++;
            //         x >>= 1;
            //     }

            //     return result;
            // }

            var A = new ulong[N];
            A[0] = 1UL << T[0];
            var maxA = A[0];
            for (var i = 1; i < N; i++)
            {
                var mask = 1UL << T[i];
                if (mask > maxA)
                {
                    A[i] = mask;
                }
                else
                {
                    var y = maxA & ~(mask - 1);

                    for (var j = T[i]; j < 45 && y <= maxA; j++)
                    {
                        if (j == T[i])
                        {
                            y |= 1UL << j;
                        }
                        else
                        {
                            y += 1UL << j;
                        }
                    }

                    A[i] = y;
                    // for (var j = 45; j >= 0; j--) Console.Write(y >> j & 1);
                    // Console.Write($"T:{T[i]} A:{A[i]} ");
                    // Console.WriteLine();

                }

                maxA = Math.Max(maxA, A[i]);
            }

            // Console.WriteLine(string.Join(" ", A));
            // Console.WriteLine(string.Join(" ", A.Select(x => Ctz(x))));
            Console.WriteLine(A[^1]);
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
