using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var T = Scanner.Scan<int>();
            while (T-- > 0)
            {
                var (N, S, K) = Scanner.Scan<int, int, int>();
                var answer = -1L;
                var gcd = GreatestCommonDivisor(N, K);
                if (S % gcd == 0)
                {
                    ExtendedGreatestCommonDivisor(N, K, out _, out var y);
                    answer = -y * (S / gcd) % (N / gcd);
                    if (answer < 0) answer += N / gcd;
                }

                Console.WriteLine(answer);
            }
        }

        public static long LeastCommonMultiple(long a, long b) => a / GreatestCommonDivisor(a, b) * b;
        private static long GreatestCommonDivisor(long a, long b)
        {
            while (true)
            {
                if (b == 0) return a;
                (a, b) = (b, a % b);
            }
        }
        private static long ExtendedGreatestCommonDivisor(long a, long b, out long x, out long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }
            var d = ExtendedGreatestCommonDivisor(b, a % b, out y, out x);
            y -= a / b * x;
            return d;
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
