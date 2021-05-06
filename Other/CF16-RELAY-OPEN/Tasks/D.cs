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
            var X00 = Scanner.Scan<int>();
            var X01 = Scanner.Scan<int>();
            var X11 = Scanner.Scan<int>();

            for (var s = 0; s <= 300; s++)
            {
                var X02 = s - X00 - X01;
                var X21 = s - X01 - X11;
                var X22 = s - X00 - X11;
                var X20 = s - X21 - X22;
                var X10 = s - X00 - X20;
                var X12 = s - X02 - X22;

                var r0 = X00 + X01 + X02;
                var r1 = X10 + X11 + X12;
                var r2 = X20 + X21 + X22;
                var c0 = X00 + X10 + X20;
                var c1 = X01 + X11 + X21;
                var c2 = X02 + X12 + X22;
                var x0 = X00 + X11 + X22;
                var x1 = X02 + X11 + X20;
                if (new[] { r0, r1, r2, c0, c1, c2, x0, x1 }.All(x => x == s))
                {
                    Console.WriteLine($"{X00} {X01} {X02}");
                    Console.WriteLine($"{X10} {X11} {X12}");
                    Console.WriteLine($"{X20} {X21} {X22}");
                    return;
                }
            }
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
