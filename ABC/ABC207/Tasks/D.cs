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
            var N = Scanner.Scan<int>();
            if (N == 1) { Console.WriteLine("Yes"); return; }
            var P = new Vector2[2][];
            var G = new Vector2[2];
            for (var k = 0; k < 2; k++)
            {
                P[k] = new Vector2[N];
                G[k] = new Vector2();
                for (var i = 0; i < N; i++)
                {
                    var (a, b) = Scanner.Scan<int, int>();
                    a *= N;
                    b *= N;
                    var p = new Vector2(a, b);
                    P[k][i] = p;
                    G[k] += p;
                }
                G[k] /= N;

                for (var i = 0; i < N; i++)
                {
                    P[k][i] -= G[k];
                }
            }

            Console.WriteLine(string.Join(" ", P[0]));

            const double eps = 1e-6;

            for (var i = 0; i < N; i++)
            {
                var rad = Math.Atan2(P[1][i].Y, P[1][i].X) - Math.Atan2(P[0][0].Y, P[0][0].X);
                var (sin, cos) = (Math.Sin(rad), Math.Cos(rad));
                var ok = true;
                for (var j = 0; j < N; j++)
                {
                    var x = P[0][j].X * cos - P[0][j].Y * sin;
                    var y = P[0][j].X * sin + P[0][j].Y * cos;
                    Console.WriteLine($"{x} {y}");
                    // var ok2 = false;
                    // for (var k = 0; k < N; k++)
                    // {
                    //     ok |= Math.Abs(P[1][k].X - x) < eps && Math.Abs(P[1][k].Y - y) < eps;
                    // }
                }

                // if (ok)
                // {
                //     Console.WriteLine(rad);
                //     Console.WriteLine("Yes");
                //     return;
                // }
            }

            Console.WriteLine("No");
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
