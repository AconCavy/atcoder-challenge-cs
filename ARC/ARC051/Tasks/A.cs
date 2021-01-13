using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var (x1, y1, r) = Scanner.Scan<int, int, int>();
            var (x2, y2, x3, y3) = Scanner.Scan<int, int, int, int>();
            var (ans1, ans2) = (true, false);
            x2 -= x1;
            x3 -= x1;
            y2 -= y1;
            y3 -= y1;

            double Distance(int x, int y) => Math.Sqrt(x * x + y * y);

            // Console.WriteLine($"x2:{x2} y2:{y2} x3:{x3} y3:{y3}");
            if (x2 <= -r && y2 <= -r && x3 >= r && y3 >= r) ans1 = false;
            if (Distance(x2, y2) > r || Distance(x2, y3) > r || Distance(x3, y2) > r || Distance(x3, y3) > r) ans2 = true;

            Console.WriteLine(ans1 ? "YES" : "NO");
            Console.WriteLine(ans2 ? "YES" : "NO");
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
