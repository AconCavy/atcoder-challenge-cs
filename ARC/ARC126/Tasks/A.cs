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
            var T = Scanner.Scan<int>();
            while (T-- > 0)
            {
                var (n2, n3, n4) = Scanner.Scan<long, long, long>();
                var n6 = n3 / 2;
                var n10 = 0L;

                // 6 + 4
                var tmp = Math.Min(n6, n4);
                n10 += tmp;
                n6 -= tmp;
                n4 -= tmp;

                // 6 + 2 + 2
                tmp = Math.Min(n6, n2 / 2);
                n10 += tmp;
                n6 -= tmp;
                n2 -= tmp * 2;

                // 4 + 4 + 2
                tmp = Math.Min(n4 / 2, n2);
                n10 += tmp;
                n4 -= tmp * 2;
                n2 -= tmp;

                // 4 + 2 + 2 + 2
                tmp = Math.Min(n4, n2 / 3);
                n10 += tmp;
                n4 -= tmp;
                n2 -= tmp * 3;

                n10 += n2 / 5;
                Console.WriteLine(n10);
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
