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
            var (N, M) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var B = new long[M];
            var C = new int[M][];
            for (var i = 0; i < M; i++)
            {
                var arr = Scanner.ScanEnumerable<int>().ToArray();
                B[i] = arr[0];
                C[i] = arr[2..].Select(x => x - 1).ToArray();
            }

            var answer = 0L;
            for (var s = 0; s < 1 << N; s++)
            {
                var sum = 0L;
                var n = 0;
                for (var i = 0; i < N; i++)
                {
                    if ((s >> i & 1) == 1)
                    {
                        sum += A[i];
                        n++;
                    }
                }

                if (n > 9) continue;

                for (var i = 0; i < M; i++)
                {
                    var m = 0;
                    foreach (var idx in C[i])
                    {
                        if ((s >> idx & 1) == 1) m++;
                    }

                    if (m >= 3) sum += B[i];
                }

                answer = Math.Max(answer, sum);
            }

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
