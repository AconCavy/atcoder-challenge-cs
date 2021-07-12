using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class CA
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
            var (H, W) = Scanner.Scan<int, int>();
            var A = new int[H][];
            var B = new int[H][];
            for (var i = 0; i < 2; i++)
            {
                var C = i % 2 == 0 ? A : B;
                for (var j = 0; j < H; j++)
                {
                    C[j] = Scanner.ScanEnumerable<int>().ToArray();
                }
            }

            var answer = 0L;
            for (var i = 0; i + 1 < H; i++)
            {
                for (var j = 0; j + 1 < W; j++)
                {
                    var d = B[i][j] - A[i][j];
                    A[i][j] += d;
                    A[i + 1][j] += d;
                    A[i][j + 1] += d;
                    A[i + 1][j + 1] += d;
                    answer += Math.Abs(d);
                }
            }

            var ok = true;
            for (var i = 0; i < H; i++)
            {
                ok &= A[i][W - 1] == B[i][W - 1];
            }
            for (var i = 0; i < W; i++)
            {
                ok &= A[H - 1][i] == B[H - 1][i];
            }

            if (ok)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine("No");
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
