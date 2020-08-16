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
            var A = Scanner.Scan<long>();
            var B = Scanner.Scan<long>();
            var C = Scanner.Scan<long>();
            var p = (long)1e9 + 7;

            var AB = (A * B) % p;
            var AC = (A * C) % p;
            var BC = (B * C) % p;

            var cTop = (BC - AB + p) % p;
            var cBottom = (AC - BC + AB + p) % p;
            var rTop = (BC - AC + p) % p;
            var rBottom = (AB - BC + AC + p) % p;

            var c = (cTop * Power(cBottom, p - 2, p)) % p;
            var r = (rTop * Power(rBottom, p - 2, p)) % p;

            Console.WriteLine($"{r} {c}");
        }

        public static long Power(long x, long y, long mod)
        {
            var result = 1L;
            while (y > 0)
            {
                var xmod = x % mod;
                if ((y & 1) == 1) result = (result * xmod) % mod;
                x = (xmod * xmod) % mod;
                y >>= 1;
            }
            return result;
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
        }
    }
}
