using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var (H, W, D) = Scanner.Scan<int, int, int>();
            var A = new (int X, int Y)[H * W];
            for (var i = 0; i < H; i++)
            {
                var a = Scanner.ScanEnumerable<int>().ToArray();
                for (var j = 0; j < a.Length; j++)
                {
                    A[a[j] - 1] = (j, i);
                }
            }

            var costs = new int[H * W];
            for (var i = 0; i < D; i++)
            {
                var prev = A[i];
                for (var j = D; i + j < H * W; j += D)
                {
                    var current = A[i + j];
                    costs[i + j] = Math.Abs(current.X - prev.X) + Math.Abs(current.Y - prev.Y) + costs[i + j - D];
                    prev = current;
                }
            }

            var Q = int.Parse(Console.ReadLine());
            for (var i = 0; i < Q; i++)
            {
                var (l, r) = Scanner.Scan<int, int>();
                Console.WriteLine(costs[--r] - costs[--l]);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
