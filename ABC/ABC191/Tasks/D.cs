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
            var (X, Y, R) = Scanner.Scan<decimal, decimal, decimal>();
            var m = (long)1e4;
            var rx = (long)(X * m);
            var ry = (long)(Y * m);
            var r = (long)(R * m);
            var rr = r * r;

            long Count(long l, long r)
            {
                if (r < 0) return (r + 1) / m - l / m;
                if (l > 0) return r / m - (l - 1) / m;
                return r / m - l / m + 1;
            }

            long Sqrt(long x)
            {
                var r = (long)Math.Sqrt(x) - 1;
                while ((r + 1) * (r + 1) <= x) r++;
                return r;
            }

            var answer = 0L;
            for (var x = (rx - r) / m; x <= (rx + r) / m; x++)
            {
                var dx = rx - x * m;
                var dy = Sqrt(rr - dx * dx);
                answer += Count(ry - dy, ry + dy);
            }

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
