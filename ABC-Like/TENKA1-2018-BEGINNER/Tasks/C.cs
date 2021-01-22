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
            var A = new int[N].Select(_ => Scanner.Scan<int>()).ToArray();

            long F(int[] array)
            {
                var (l, r) = (0, N);
                var sum = 0L;
                var (a, b) = (array[0], array[0]);
                while (r - l > 1)
                {
                    if (r - l > 1)
                    {
                        sum += Math.Abs(array[--r] - a);
                        a = array[r];
                    }

                    if (r - l > 1)
                    {
                        sum += Math.Abs(array[--r] - b);
                        b = array[r];
                    }

                    if (r - l > 1)
                    {
                        sum += Math.Abs(array[++l] - a);
                        a = array[l];
                    }

                    if (r - l > 1)
                    {
                        sum += Math.Abs(array[++l] - b);
                        b = array[l];
                    }
                }

                return sum;
            }

            Array.Sort(A);
            var answer = F(A);
            Array.Reverse(A);
            answer = Math.Max(answer, F(A));

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
