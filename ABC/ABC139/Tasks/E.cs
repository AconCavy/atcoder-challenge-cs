using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var A = new int[N][].Select(_ => Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray()).ToArray();
            var Q = new Queue<int>[N];
            for (var i = 0; i < N; i++) Q[i] = new Queue<int>(A[i]);
            var answer = 0;
            var prev = new HashSet<int>(Enumerable.Range(0, N));
            while (true)
            {
                var current = new HashSet<int>();
                foreach (var x in prev)
                {
                    if (!Q[x].Any()) continue;
                    var y = Q[x].Peek();
                    if (current.Contains(x) || current.Contains(y)) continue;
                    if (Q[y].Peek() != x) continue;
                    Q[x].Dequeue();
                    Q[y].Dequeue();
                    current.Add(x);
                    current.Add(y);
                }
                prev = current;
                if (!current.Any()) break;
                answer++;
            }

            if (Q.Any(x => x.Any())) answer = -1;
            Console.WriteLine(answer);
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
