using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class F
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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new (int l, int r)[H];
            for (var i = 0; i < H; i++)
            {
                var (A, B) = Scanner.Scan<int, int>();
                G[i] = (A - 1, B - 1);
            }

            // var inf = (long)1e18;
            // var answer = Enumerable.Repeat(inf, W).ToArray();
            // for (var k = W - 1; k >= 0; k--)
            // {
            //     var x = k;
            //     var tmp = 0L;
            //     for (var i = 0; i < H; i++)
            //     {
            //         while (x < W)
            //         {
            //             tmp++;
            //             if (tmp > answer[i]) break;
            //             if (x < G[i].l || G[i].r < x) break;
            //             else x++;
            //         }
            //         if (x >= W) tmp = inf;
            //         answer[i] = Math.Min(answer[i], tmp);
            //     }
            // }

            // foreach (var count in answer)
            // {
            //     Console.WriteLine(count != (long)1e18 ? count : -1);
            // }
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
