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
            var (N, M) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            Array.Sort(A);
            var max = Math.Max(M, A[^1]);
            var sieve = new bool[max + 1];
            foreach (var a in A)
            {
                foreach (var d in GetDivisors(a))
                {
                    if (d == 1) continue;
                    if (sieve[d]) continue;
                    for (var i = d; i <= max; i += d)
                    {
                        sieve[i] = true;
                    }
                }
            }

            var answers = new List<int> { 1 };
            for (var i = 2; i <= M; i++)
            {
                if (!sieve[i]) answers.Add(i);
            }

            Console.WriteLine(answers.Count);
            Console.WriteLine(string.Join("\n", answers));
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
