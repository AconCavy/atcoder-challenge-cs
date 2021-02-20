using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var X = Scanner.Scan<string>();
            var Y = X.Select(x => (long)x - '0').ToArray();
            var M = Scanner.Scan<long>();
            if (Y.Length == 1)
            {
                Console.WriteLine(Y[0] <= M ? 1 : 0);
                return;
            }
            var d = (long)X.Max() - '0';

            bool F(long n)
            {
                var result = 0L;

                foreach (var y in Y)
                {
                    if (Math.Log2(result) + Math.Log2(n) >= 60) return false;
                    result *= n;
                    result += y;
                    if (result > M) return false;
                }

                return result <= M;
            }

            const long inf = (long)3e18;
            var (l, r) = (d, inf);
            while (r - l > 1L)
            {
                var m = (l + r) / 2;
                if (F(m)) l = m;
                else r = m;
            }

            var answer = r - d - 1;
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
