using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
                var (A, B, C) = Scanner.Scan<long, long, long>();
                var (a, b, c) = ((decimal)A, (decimal)B, (decimal)C);
                if (A == 0)
                {
                    if (B == 0)
                    {
                        if (C == 0) Console.WriteLine(3);
                        else Console.WriteLine(0);
                    }
                    else
                    {
                        var x = -c / b;
                        Console.WriteLine($"1 {x}");
                    }
                }
                else
                {
                    var d = B * B - 4 * A * C;
                    if (d < 0)
                    {
                        Console.WriteLine(0);
                        continue;
                    }

                    if (d == 0)
                    {
                        var x = -b / (2 * a);
                        Console.WriteLine($"1 {x}");
                        continue;
                    }

                    var k = Sqrt(d);
                    var x0 = (-b - k) / (2 * a);
                    var x1 = (-b + k) / (2 * a);
                    if (x0 > x1) (x0, x1) = (x1, x0);
                    Console.WriteLine($"2 {x0} {x1}");
                }
            }
        }

        public static decimal Sqrt(decimal x)
        {
            (decimal l, decimal r) = (1, x);
            const decimal eps = (decimal)0.0000000001;
            while (r - l > eps)
            {
                var m = (l + r) / 2;
                if (m * m > x) r = m;
                else l = m;
            }

            return l;
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
