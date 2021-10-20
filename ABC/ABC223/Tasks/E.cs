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
            var (X, Y, A, B, C) = Scanner.Scan<long, long, long, long, long>();

            bool Check2(long x, long y, long s1, long s2)
            {
                if (x == 0) return false;
                y -= (s1 + x - 1) / x;
                return x * y >= s2;
            }

            bool Check3(long x, long y, long s1, long s2, long s3)
            {
                if (x == 0) return false;
                y -= (s1 + x - 1) / x;
                return Check2(x, y, s2, s3) || Check2(y, x, s2, s3);
            }

            var answer = false;
            for (var i = 0; i < 2; i++)
            {
                answer |= Check3(X, Y, A, B, C);
                answer |= Check3(X, Y, A, C, B);
                answer |= Check3(X, Y, B, A, C);
                answer |= Check3(X, Y, B, C, A);
                answer |= Check3(X, Y, C, A, B);
                answer |= Check3(X, Y, C, B, A);
                (X, Y) = (Y, X);
            }

            Console.WriteLine(answer ? "Yes" : "No");
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
