using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var input = Scanner.ScanEnumerable<long>().ToArray();
            var (Sx, Sy) = (input[0], input[1]);
            var (Tx, Ty) = (input[2], input[3]);
            var (T, V) = (input[4], input[5]);
            var N = Scanner.Scan<int>();
            var X = new long[N];
            var Y = new long[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<long, long>();
                X[i] = x;
                Y[i] = y;
            }

            var answer = false;
            for (var i = 0; i < N && !answer; i++)
            {
                var dx = X[i] - Sx;
                var dy = Y[i] - Sy;
                var tmp1 = Math.Sqrt(dx * dx + dy * dy);
                var t1 = (tmp1) / V;

                dx = Tx - X[i];
                dy = Ty - Y[i];
                var tmp2 = Math.Sqrt(dx * dx + dy * dy);
                var t2 = (tmp2) / V;

                if (t1 + t2 <= T) answer = true;
            }

            Console.WriteLine(answer ? "YES" : "NO");
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
