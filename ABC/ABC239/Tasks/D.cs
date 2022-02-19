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
            var (A, B, C, D) = Scanner.Scan<int, int, int, int>();
            var P = Prime.Sieve(200);
            var answer = false;
            for (var i = A; i <= B; i++)
            {
                var exist = false;
                foreach (var p in P)
                {
                    var j = p - i;
                    exist |= C <= j && j <= D;
                }

                answer |= !exist;
            }
            Console.WriteLine(answer ? "Takahashi" : "Aoki");
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
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
