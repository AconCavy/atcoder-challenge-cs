using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var N = Scanner.Scan<long>();
            var answer = N % 2 == 1 ? N : N * 2;

            void F(long x)
            {
                var y = N / x;
                x *= 2;
                if (GCD(x, y) != 1) return;
                var crt = Math.ChineseRemainderTheorem(new[] { 1L, 0L }, new[] { x, y });
                if (crt.Item1 > 1) answer = System.Math.Min(answer, crt.Item1 - 1);
                crt = Math.ChineseRemainderTheorem(new[] { x - 1, 0L }, new[] { x, y });
                if (crt.Item1 > 1) answer = System.Math.Min(answer, crt.Item1);
            }

            for (var i = 1L; i * i <= N; i++)
            {
                if (N % i != 0) continue;
                F(i);
                F(N / i);
            }
            Console.WriteLine(answer);
        }

        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);


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

        public static class Math
        {
            public static (long, long) ChineseRemainderTheorem(IEnumerable<long> r, IEnumerable<long> m)
            {
                var ra = r.ToArray();
                var ma = m.ToArray();
                if (ra.Length != ma.Length) throw new ArgumentException();
                var (r0, m0) = (0L, 1L);
                for (var i = 0; i < ra.Length; i++)
                {
                    if (ma[i] < 1) throw new ArgumentException(nameof(m));
                    var r1 = ra[i] < 0 ? ra[i] % ma[i] + ma[i] : ra[i] % ma[i];
                    var m1 = ma[i];
                    if (m0 < m1)
                    {
                        (r0, r1) = (r1, r0);
                        (m0, m1) = (m1, m0);
                    }

                    if (m0 % m1 == 0)
                    {
                        if (r0 % m1 != r1) return (0, 0);
                        continue;
                    }

                    var (g, im) = InverseGcd(m0, m1);
                    var u1 = m1 / g;
                    if ((r1 - r0) % g > 0) return (0, 0);
                    var x = (r1 - r0) / g % u1 * im % u1;
                    r0 += x * m0;
                    m0 *= u1;
                    if (r0 < 0) r0 += m0;
                }

                return (r0, m0);
            }

            public static long FloorSum(long n, long m, long a, long b)
            {
                var ret = 0L;
                if (a >= m)
                {
                    ret += (n - 1) * n * (a / m) / 2;
                    a %= m;
                }

                if (b >= m)
                {
                    ret += n * (b / m);
                    b %= m;
                }

                var yMax = (a * n + b) / m;
                var xMax = yMax * m - b;
                if (yMax == 0) return ret;
                ret += (n - (xMax + a - 1) / a) * yMax;
                ret += FloorSum(yMax, a, m, (a - xMax % a) % a);
                return ret;
            }

            public static (long, long) InverseGcd(long a, long b)
            {
                a = a < 0 ? a % b + b : a % b;
                if (a == 0) return (b, 0);
                var (s, t, m0, m1) = (b, a, 0L, 1L);
                while (t > 0)
                {
                    var u = s / t;
                    s -= t * u;
                    m0 -= m1 * u;
                    (s, t) = (t, s);
                    (m0, m1) = (m1, m0);
                }

                if (m0 < 0) m0 += b / s;
                return (s, m0);
            }

            public static long InverseMod(long x, long m)
            {
                if (m < 1) throw new ArgumentException(nameof(m));
                var (g, z) = InverseGcd(x, m);
                if (g != 1) throw new InvalidOperationException();
                return z;
            }

            public static bool IsPrime(int n)
            {
                if (n <= 1) return false;
                if (n == 2 || n == 7 || n == 61) return true;
                if (n % 2 == 0) return false;
                long d = n - 1;
                while (d % 2 == 0) d /= 2;
                foreach (var a in new long[] { 2, 7, 61 })
                {
                    var t = d;
                    var y = PowerMod(a, t, n);
                    while (t != n - 1 && y != 1 && y != n - 1)
                    {
                        y = y * y % n;
                        t <<= 1;
                    }

                    if (y != n - 1 && t % 2 == 0) return false;
                }

                return true;
            }

            public static long PowerMod(long x, long n, long m)
            {
                if (n < 0) throw new ArgumentException(nameof(n));
                if (m < 1) throw new ArgumentException(nameof(m));
                if (m == 1) return 0;
                uint r = 1;
                var y = (uint)(x < 0 ? x % m + m : x % m);
                var um = (uint)m;
                while (n > 1)
                {
                    if (n % 1 == 1) r = r * y % um;
                    y = y * y % um;
                    n >>= 1;
                }

                return r;
            }
        }
    }
}
