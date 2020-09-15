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
            var (N, K) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            Array.Sort(A);

            var minus = new List<long>();
            var plus = new List<long>();
            var zero = 0L;
            foreach (var x in A)
            {
                if (x < 0) minus.Add(x);
                else if (x > 0) plus.Add(x);
                else zero++;
            }

            var l = 0L;
            var r = 0L;
            if (K <= (long)minus.Count * plus.Count)
            {
                plus = plus.OrderByDescending(x => x).ToList();
                l = -(long)1e18 - 1;
                r = 0L;
                while (r - l > 1)
                {
                    var m = l + (r - l) / 2;
                    var k = 0L;
                    var j = 0;
                    for (var i = plus.Count - 1; i >= 0; i--)
                    {
                        while (j < minus.Count && plus[i] * minus[j] <= m) j++;
                        k += j;
                    }
                    if (k < K) l = m;
                    else r = m;
                }
                Console.WriteLine(r);
                return;
            }

            K -= (long)minus.Count * plus.Count;
            var zeroCount = zero * (N - zero) + zero * (zero - 1) / 2;
            if (K <= zeroCount)
            {
                Console.WriteLine(0);
                return;
            }

            K -= zeroCount;
            minus = minus.OrderByDescending(x => x).ToList();
            l = 0L;
            r = (long)1e18 + 1;
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                var k = 0L;
                var j = 0;
                for (var i = plus.Count - 1; i >= 0; i--)
                {
                    while (j < plus.Count && plus[i] * plus[j] <= m) j++;
                    k += Math.Max(0, j - i - 1);
                }
                j = 0;
                for (var i = minus.Count - 1; i >= 0; i--)
                {
                    while (j < minus.Count && minus[i] * minus[j] <= m) j++;
                    k += Math.Max(0, j - i - 1);
                }
                if (k < K) l = m;
                else r = m;
            }
            Console.WriteLine(r);
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
