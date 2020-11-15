using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var B = Scanner.ScanEnumerable<int>().ToArray();

            var answer = 0;
            for (var k = 0; k <= 28; k++)
            {
                var mod = (1 << (k + 1)) - 1;
                var ma = new int[N];
                var mb = new int[N];
                for (var i = 0; i < N; i++)
                {
                    ma[i] = A[i] & mod;
                    mb[i] = B[i] & mod;
                }

                int LowerBound(int key)
                {
                    var (l, r) = (-1, N);
                    while (r - l > 1)
                    {
                        var m = l + (r - l) / 2;
                        if (mb[m] >= key) r = m;
                        else l = m;
                    }
                    return r;
                }

                Array.Sort(mb);
                var t = 1 << k;
                var op = 0;
                for (var i = 0; i < N; i++)
                {
                    var t1 = LowerBound(t - ma[i]);
                    var t2 = LowerBound(2 * t - ma[i]);
                    var t3 = LowerBound(3 * t - ma[i]);
                    op += t2 - t1 + N - t3;
                }
                answer |= (op & 1) << k;
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
