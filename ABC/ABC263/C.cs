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
            var (N, M) = Scanner.Scan<int, int>();
            var items = Enumerable.Range(1, M).ToArray();
            foreach (var values in items.Permute(N))
            {
                var ok = true;
                for (var i = 1; i < values.Length; i++)
                {
                    ok &= values[i] > values[i - 1];
                }

                if (ok)
                {
                    Console.WriteLine(string.Join(" ", values));
                }
            }
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

    public static partial class EnumerableExtension
    {
        /// <summary>
        ///     Returns the permutation sequences from the original sequence. (nPr patterns).
        /// </summary>
        /// <param name="source">A sequence of values.</param>
        /// <param name="count">A number of objects selected.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <returns>The permutation sequences from the original sequence.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">count &lt;= 0 or source.Count() &gt; count</exception>
        /// <code>
        /// var permutation = new []{ 1, 2, 3 }.Permute(3);
        /// permutation: { { 1, 2, 3 }, { 1, 3, 2 }, { 2, 1, 3 }, { 2, 3, 1 }, { 3, 1, 2 }, { 3, 2, 1 } }
        /// </code>
        public static IEnumerable<TSource[]> Permute<TSource>(this IEnumerable<TSource>? source, int count)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            IEnumerable<TSource[]> Inner()
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
                TSource[] Result()
                {
                    var result = new TSource[count];
                    for (var i = 0; i < count; i++)
                    {
                        result[i] = items[indices[i]];
                    }
                    return result;
                }
                yield return Result();
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
                            yield return Result();
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
