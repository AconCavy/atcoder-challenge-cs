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
            var C = new (int A, int B)[N];
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                C[i] = (a, b);
            }

            var da = GetDivisors(C[0].A).ToArray();
            var db = GetDivisors(C[0].B).ToArray();
            var answer = 1L;
            foreach (var x in da)
            {
                foreach (var y in db)
                {
                    var ok = true;
                    foreach (var (a, b) in C)
                    {
                        if (a % x == 0 && b % y == 0 || b % x == 0 && a % y == 0) continue;
                        ok = false;
                    }

                    if (ok) answer = Math.Max(answer, Lcm(x, y));
                }
            }

            Console.WriteLine(answer);
        }

        public static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
        public static long Lcm(long a, long b) => a / Gcd(a, b) * b;

        public static IEnumerable<long> GetDivisors(long n)
        {
            for (var i = 1L; i * i <= n; i++)
            {
                if (n % i != 0) continue;
                yield return i;
                if (n / i != i) yield return n / i;
            }
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
