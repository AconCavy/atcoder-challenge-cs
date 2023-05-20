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
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, M) = Scanner.Scan<int, int>();
            var S = new string[N];
            for (var i = 0; i < N; i++)
            {
                S[i] = Scanner.Scan<string>();
            }

            foreach (var perm in Permute(Enumerable.Range(0, N)))
            {
                var answer = true;
                for (var k = 0; k + 1 < N; k++)
                {
                    var curr = perm[k];
                    var next = perm[k + 1];
                    var diff = 0;
                    for (var i = 0; i < M; i++)
                    {
                        if (S[curr][i] != S[next][i]) diff++;
                    }

                    answer &= diff == 1;
                }

                if (answer)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
        }

        public static IEnumerable<T[]> Permute<T>(IEnumerable<T> source)
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
                T[] Result()
                {
                    var result = new T[n];
                    for (var i = 0; i < n; i++)
                    {
                        result[i] = items[indices[i]];
                    }
                    return result;
                }
                yield return Result();
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
                    yield return Result();
                }
            }
            return Inner();
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
