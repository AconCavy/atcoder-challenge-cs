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
            var (N, M) = Scanner.Scan<int, int>();
            var G = new Queue<int>[M];
            var color = new Queue<int>[N].Select(_ => new Queue<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var K = Scanner.Scan<int>();
                G[i] = new Queue<int>(Scanner.ScanEnumerable<int>().Select(x => x - 1));
                color[G[i].Peek()].Enqueue(i);
            }

            var queue = new Queue<(int, int)>();
            for (var i = 0; i < N; i++)
            {
                if (color[i].Count == 2)
                {
                    queue.Enqueue((color[i].Dequeue(), color[i].Dequeue()));
                }
            }

            while (queue.Count > 0)
            {
                var (a, b) = queue.Dequeue();
                G[a].Dequeue();
                G[b].Dequeue();

                if (G[a].Count > 0)
                {
                    var idx = G[a].Peek();
                    color[idx].Enqueue(a);
                    if (color[idx].Count == 2)
                    {
                        queue.Enqueue((color[idx].Dequeue(), color[idx].Dequeue()));
                    }
                }
                if (G[b].Count > 0)
                {
                    var idx = G[b].Peek();
                    color[idx].Enqueue(b);
                    if (color[idx].Count == 2)
                    {
                        queue.Enqueue((color[idx].Dequeue(), color[idx].Dequeue()));
                    }
                }
            }


            var answer = true;
            for (var i = 0; i < M && answer; i++)
            {
                answer &= G[i].Count == 0;
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
