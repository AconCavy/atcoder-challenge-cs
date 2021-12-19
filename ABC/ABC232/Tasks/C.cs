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
            var (N, M) = Scanner.Scan<int, int>();
            var E1 = new bool[N, N];
            var E2 = new (int A, int B)[M];
            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                E1[a, b] = E1[b, a] = true;
            }

            for (var i = 0; i < M; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                a--; b--;
                E2[i] = (a, b);
            }

            foreach (var order in Enumerable.Range(0, N).Permute())
            {
                var ok = true;
                foreach (var (c, d) in E2)
                {
                    ok &= E1[order[c], order[d]];
                }

                if (ok)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
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

    public static partial class EnumerableExtension
    {
        public static IEnumerable<T[]> Permute<T>(this IEnumerable<T> source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            IEnumerable<T[]> Inner()
            {
                var items = source.ToArray();
                var n = items.Length;
                var indices = new int[n];
                for (var i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }
                var result = new T[n];
                void Fill()
                {
                    for (var i = 0; i < n; i++)
                    {
                        result[i] = items[indices[i]];
                    }
                }
                Fill();
                yield return result;
                while (true)
                {
                    var (i, j) = (n - 2, n - 1);
                    while (i >= 0)
                    {
                        if (indices[i] < indices[i + 1]) break;
                        i--;
                    }
                    if (i == -1) yield break;
                    while (true)
                    {
                        if (indices[j] > indices[i]) break;
                        j--;
                    }
                    (indices[i], indices[j]) = (indices[j], indices[i]);
                    Array.Reverse(indices, i + 1, n - 1 - i);
                    Fill();
                    yield return result;
                }
            }
            return Inner();
        }
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> source, int count)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            IEnumerable<T[]> Inner()
            {
                var items = source.ToArray();
                if (count <= 0 || items.Length < count) throw new ArgumentOutOfRangeException(nameof(count));
                var n = items.Length;
                var indices = new int[n];
                for (var i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }
                var cycles = new int[count];
                for (var i = 0; i < cycles.Length; i++)
                {
                    cycles[i] = n - i;
                }
                var result = new T[count];
                void Fill()
                {
                    for (var i = 0; i < count; i++)
                    {
                        result[i] = items[indices[i]];
                    }
                }
                Fill();
                yield return result;
                while (true)
                {
                    var done = true;
                    for (var i = count - 1; i >= 0; i--)
                    {
                        cycles[i]--;
                        if (cycles[i] == 0)
                        {
                            for (var j = i; j + 1 < indices.Length; j++)
                            {
                                (indices[j], indices[j + 1]) = (indices[j + 1], indices[j]);
                            }
                            cycles[i] = n - i;
                        }
                        else
                        {
                            (indices[i], indices[^cycles[i]]) = (indices[^cycles[i]], indices[i]);
                            Fill();
                            yield return result;
                            done = false;
                            break;
                        }
                    }
                    if (done) yield break;
                }
            }
            return Inner();
        }
    }
}
