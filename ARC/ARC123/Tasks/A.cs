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
            var (A, B, C) = Scanner.Scan<long, long, long>();
            var d1 = B - A;
            var d2 = C - B;
            // B => d1 + 1, d2 - 1
            // A => d1 - 1
            // C => d2 + 1
            var answer = 0L;
            var k = Math.Max(0, (d2 - d1) / 2);
            answer += k;
            B += k;
            d1 = B - A;
            d2 = C - B;
            if (d1 >= d2)
            {
                answer += d1 - d2;
            }
            else
            {
                answer += (d2 - d1) * 2;
            }

            Console.WriteLine(answer);
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
