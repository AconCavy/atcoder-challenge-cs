using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class G
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
            var (N, M, Q) = Scanner.Scan<int, int, int>();
            var G = new List<Node>[N].Select(x => new List<Node>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (a, b, c) = Scanner.Scan<int, int, int>();
                a--; b--;
                G[a].Add(new Node(b, c));
                G[b].Add(new Node(a, c));
            }
            for (var i = 0; i < N; i++)
            {
                G[i].Sort((x, y) => x.Cost.CompareTo(y.Cost));
            }

            var QG = G.Select(x => new Queue<Node>(x)).ToArray();
            var X = Scanner.ScanEnumerable<long>().ToArray();

            var queue = new Queue<Data>();
            queue.Enqueue(new Data(0, 0));
            var used = new bool[N];
            used[0] = true;
            var answer = new int[Q + 1];
            answer[0] = 1;

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                if (u.Day >= Q) break;
                var nd = u.Day + 1;
                var que = QG[u.ID];
                while (que.Count > 0)
                {
                    var v = que.Peek();
                    if (used[v.ID])
                    {
                        que.Dequeue();
                        continue;
                    }

                    if (v.Cost > X[u.Day]) break;
                    que.Dequeue();
                    used[v.ID] = true;
                    answer[nd]++;
                    queue.Enqueue(new Data(v.ID, nd));
                }

                if (que.Count > 0)
                {
                    queue.Enqueue(new Data(u.ID, nd));
                }
            }

            for (var i = 1; i <= Q; i++)
            {
                answer[i] += answer[i - 1];
            }

            Console.WriteLine(string.Join("\n", answer.Skip(1)));
        }

        public readonly struct Node
        {
            public readonly int ID;
            public readonly int Cost;
            public Node(int id, int cost) => (ID, Cost) = (id, cost);
        }

        public readonly struct Data
        {
            public readonly int ID;
            public readonly int Day;
            public Data(int id, int day) => (ID, Day) = (id, day);
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
