using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var B = Scanner.ScanEnumerable<long>().ToArray();

            bool F(IEnumerable<long> a, IEnumerable<long> b) => a.Zip(b).All(x => x.First == x.Second);

            void Swap<T>(T[] array, int idx)
            => (array[idx], array[idx + 1], array[idx + 2]) = (array[idx + 2], array[idx], array[idx + 1]);

            if (N == 3)
            {
                for (var k = 0; k < 3; k++)
                {
                    if (F(A, B))
                    {
                        Console.WriteLine("Yes");
                        return;
                    }

                    Swap(A, 0);
                }

                Console.WriteLine("No");
                return;
            }

            for (var i = 0; i + 3 < N; i++)
            {
                var idx = Array.IndexOf(A, B[i], i);
                if (idx == -1)
                {
                    Console.WriteLine("No");
                    return;
                }

                for (var j = idx; j - 2 >= i; j -= 2)
                {
                    Swap(A, j - 2);
                }

                while (A[i] != B[i]) Swap(A, i);
            }

            long Encode(long[] array)
            {
                long result = 0;
                foreach (var v in array)
                {
                    result *= 10000;
                    result += v;
                }

                return result;
            }

            long[] Decode(long v)
            {
                var result = new long[4];
                for (var i = 3; i >= 0; i--)
                {
                    result[i] = v % 10000;
                    v /= 10000;
                }

                return result;
            }

            var C = A[^4..];
            var D = B[^4..];

            var set = new HashSet<long>();
            var queue = new Queue<long>();
            queue.Enqueue(Encode(C));
            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                var array = Decode(u);
                for (var i = 0; i < 2; i++)
                {
                    for (var k = 0; k < 3; k++)
                    {
                        Swap(array, i);
                        var v = Encode(array);
                        if (!set.Contains(v))
                        {
                            set.Add(v);
                            queue.Enqueue(v);
                        }
                    }
                }
            }

            Console.WriteLine(set.Contains(Encode(D)) ? "Yes" : "No");
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
