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
            var sieve = new bool[M + 1];
            foreach (var a in A)
            {
                foreach (var (p, _) in Prime.GetFactorDictionary(a))
                {
                    if (p > M || sieve[p]) continue;
                    for (var i = p; i <= M; i += p)
                    {
                        sieve[i] = true;
                    }
                }
            }

            var answers = Enumerable.Range(1, M).Where(x => !sieve[x]).ToArray();
            Console.WriteLine(answers.Length);
            Console.WriteLine(string.Join("\n", answers));
        }

        public static class Prime
        {
            public static IEnumerable<long> GetFactors(long value)
            {
                if (value < 2) yield break;
                while (value % 2 == 0)
                {
                    yield return 2;
                    value /= 2;
                }
                for (var i = 3L; i * i <= value; i++)
                {
                    while (value % i == 0)
                    {
                        yield return i;
                        value /= i;
                    }
                }
                if (value > 1) yield return value;
            }
            public static IDictionary<long, int> GetFactorDictionary(long value)
            {
                var factors = new Dictionary<long, int>();
                if (value < 2) return factors;
                void CountUp(long n)
                {
                    if (value % n != 0) return;
                    factors[n] = 0;
                    while (value % n == 0)
                    {
                        value /= n;
                        factors[n]++;
                    }
                }
                CountUp(2);
                for (var i = 3L; i * i <= value; i += 2) CountUp(i);
                if (value > 1) factors[value] = 1;
                return factors;
            }
            public static IEnumerable<int> Sieve(int value)
            {
                if (value < 2) yield break;
                yield return 2;
                var sieve = new bool[(value + 1) / 2];
                for (var i = 1; i < sieve.Length; i++)
                {
                    if (sieve[i]) continue;
                    yield return i * 2 + 1;
                    for (var j = i; j < sieve.Length; j += i * 2 + 1) sieve[j] = true;
                }
            }
            public static bool IsPrime(long value)
            {
                if (value == 2) return true;
                if (value < 2 || value % 2 == 0) return false;
                for (var i = 3L; i * i <= value; i += 2)
                {
                    if (value % i == 0) return false;
                }
                return true;
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
