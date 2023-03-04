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
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<long>();

            var dict = new Dictionary<long, long>();

            long F(long n)
            {
                if (dict.ContainsKey(n)) return dict[n];
                long result = 0;
                for (var a = 1L; a * a <= n; a++)
                {
                    if (n % a != 0) continue;
                    var b = n / a;
                    if (a == b) result++;
                    else result += 2;
                }

                return dict[n] = result;
            }

            long answer = 0;
            for (var ab = 1; ab < N; ab++)
            {
                var cd = N - ab;
                var fab = F(ab);
                var fcd = F(cd);
                var s = fab * fcd;
                answer += s;
            }

            Console.WriteLine(answer);
        }

        public static class Prime
        {
            public static IEnumerable<long> GetFactors(long value)
            {
                if (value < 2) yield break;
                IEnumerable<long> F(long x)
                {
                    while (value % x == 0)
                    {
                        yield return x;
                        value /= x;
                    }
                }
                foreach (var v in F(2)) yield return v;
                for (var i = 3L; i * i <= value; i += 2)
                {
                    foreach (var v in F(i)) yield return v;
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
                if (value == 2 || value == 3) return true;
                if (value < 2 || value % 2 == 0 || value % 3 == 0) return false;
                for (var i = 5L; i * i <= value; i += 6)
                {
                    if (value % i == 0 || value % (i + 2) == 0) return false;
                }
                return true;
            }
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
