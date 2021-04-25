using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class J
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
            var P = new (long A, long B)[N];
            const long inf = (long)1e18;
            var (ma, mb) = (inf, inf);
            for (var i = 0; i < N; i++)
            {
                var (A, B) = Scanner.Scan<long, long>();
                P[i] = (A, B);

                if (Math.Max(ma, mb) > Math.Max(A, B)) (ma, mb) = (A, B);
            }

            var div = GetDivisors(ma).Union(GetDivisors(mb)).ToArray();
            Array.Sort(div, (x, y) => y.CompareTo(x));

            foreach (var d in div)
            {
                var ok = true;
                if (d != 1)
                {
                    foreach (var (a, b) in P)
                    {
                        ok &= Gcd(a, d) == d || Gcd(b, d) == d;
                        if (!ok) break;
                    }
                }

                if (ok)
                {
                    Console.WriteLine(d);
                    return;
                }
            }
        }

        public static IEnumerable<long> GetDivisors(long n)
        {
            for (var i = 1L; i * i <= n; i++)
            {
                if (n % i != 0) continue;
                yield return i;
                if (n / i != i) yield return n / i;
            }
        }

        public static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);

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
