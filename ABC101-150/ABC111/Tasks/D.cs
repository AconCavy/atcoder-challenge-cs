using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var N = Scanner.Scan<int>();
            var P = new (long X, long Y)[N];
            for (var i = 0; i < N; i++)
            {
                var (X, Y) = Scanner.Scan<long, long>();
                P[i] = (X, Y);
            }
            var count = P.Count(p => Math.Abs(p.X + p.Y) % 2 == 0);
            if (count != 0 && count != N) { Console.WriteLine(-1); return; }

            var D = new List<long>();
            for (var i = 30; i >= 0; i--) D.Add(1L << i);
            if (Math.Abs(P[0].X + P[0].Y) % 2 == 0) D.Add(1);
            Console.WriteLine(D.Count);
            Console.WriteLine(string.Join(" ", D));

            foreach (var (u, v) in P.Select(p => (p.X + p.Y, p.X - p.Y)))
            {
                var answer = new StringBuilder();
                var (cu, cv) = (0L, 0L);
                foreach (var d in D)
                {
                    if (cu < u)
                    {
                        if (cv < v)
                        {
                            (cu, cv) = (cu + d, cv + d);
                            answer.Append('R');
                        }
                        else
                        {
                            (cu, cv) = (cu + d, cv - d);
                            answer.Append('U');
                        }
                    }
                    else
                    {
                        if (cv < v)
                        {
                            (cu, cv) = (cu - d, cv + d);
                            answer.Append('D');
                        }
                        else
                        {
                            (cu, cv) = (cu - d, cv - d);
                            answer.Append('L');
                        }
                    }
                }

                Console.WriteLine(answer.ToString());
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
