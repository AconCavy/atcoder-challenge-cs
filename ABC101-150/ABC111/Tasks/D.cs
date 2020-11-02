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

            var A = new List<long>();
            for (var i = 30; i >= 0; i--) A.Add(1 << i);
            if (Math.Abs(P[0].X + P[0].Y) % 2 == 0) A.Add(1);
            Console.WriteLine(A.Count);
            Console.WriteLine(string.Join(" ", A));

            // var Q = P.Select(p => (p.X + p.Y, p.X - p.Y)).ToArray();
            // foreach (var (u, v) in Q)
            // {
            //     var answer = new StringBuilder();
            //     var (cu, cv) = (0L, 0L);
            //     foreach (var arm in A)
            //     {
            //         // < < < x
            //         // < > < x
            //         // < < > x
            //         // < > > x

            //         // > < < x
            //         // > > < x
            //         // > < > x
            //         // > > > x

            //         if (cu >= u)
            //         {
            //             if (cv >= v)
            //             {
            //                 (cu, cv) = (cu - arm, cv - arm);
            //                 answer.Append('L');
            //             }
            //             else
            //             {
            //                 (cu, cv) = (cu + arm, cv + arm);
            //                 answer.Append('R');
            //             }
            //         }
            //         else
            //         {
            //             if (cv >= v)
            //             {
            //                 (cu, cv) = (cu - arm, cv + arm);
            //                 answer.Append('D');
            //             }
            //             else
            //             {
            //                 (cu, cv) = (cu + arm, cv - arm);
            //                 answer.Append('U');
            //             }
            //         }
            //     }

            //     var rx = (cu + cv) / 2;
            //     var ry = cu - rx;
            //     Console.WriteLine($"{rx} {ry}");

            //     Console.WriteLine(answer.ToString());
            // }

            foreach (var (x, y) in P)
            {
                var answer = new StringBuilder();
                var (cx, cy) = (0L, 0L);
                foreach (var arm in A)
                {
                    var min = long.MaxValue;
                    var minOp = '#';
                    var (mx, my) = (0L, 0L);
                    void Update(long x, long y, char c)
                    {
                        var diff = Math.Abs(x) + Math.Abs(y);
                        if (diff < min) (minOp, mx, my, min) = (c, x, y, diff);
                    }
                    Update(cy - arm, cx, 'U');
                    Update(cy + arm, cx, 'D');
                    Update(cy, cx - arm, 'R');
                    Update(cy, cx + arm, 'L');
                    (cy, cx) = (my, my);
                    answer.Append(minOp);
                }
                Console.WriteLine($"{cx} {cy}");
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
