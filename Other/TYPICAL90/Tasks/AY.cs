using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class AY
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
            var (N, K, P) = Scanner.Scan<int, int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var list1 = new List<long>[K + 1].Select(_ => new List<long>()).ToArray();
            var list2 = new List<long>[K + 1].Select(_ => new List<long>()).ToArray();
            var n = N / 2;
            var m = N - n;
            for (var i = 0; i < 1 << n; i++)
            {
                var sum = 0L;
                var count = 0;
                for (var j = 0; j < n; j++)
                {
                    if ((i >> j & 1) == 1)
                    {
                        sum += A[j];
                        count++;
                    }
                }

                if (sum <= P && count <= K) list1[count].Add(sum);
            }

            for (var i = 0; i < 1 << m; i++)
            {
                var sum = 0L;
                var count = 0;
                for (var j = 0; j < m; j++)
                {
                    if ((i >> j & 1) == 1)
                    {
                        sum += A[n + j];
                        count++;
                    }
                }

                if (sum <= P && count <= K) list2[count].Add(sum);
            }

            for (var i = 0; i <= K; i++)
            {
                list2[i].Sort();
            }

            var answer = 0L;
            for (var i = 0; i <= K; i++)
            {
                var j = K - i;
                foreach (var x in list1[i])
                {

                    answer += UpperBound(list2[j], P - x);
                }
            }

            Console.WriteLine(answer);
        }

        public static int UpperBound(List<long> source, long key)
        {
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (source[m] > key) r = m;
                else l = m;
            }
            return r;
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
