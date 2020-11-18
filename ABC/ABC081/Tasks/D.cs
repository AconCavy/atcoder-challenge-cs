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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            const long linf = (long)1e18;
            var (min, max) = (linf, -linf);
            var (minid, maxid) = (0, 0);
            for (var i = 0; i < A.Length; i++)
            {
                if(A[i] < min)
                {
                    min = A[i];
                    minid = i;
                }
                if(A[i] > max)
                {
                    max = A[i];
                    maxid = i;
                }
            }
            
            var x = min;
            var idx = minid;
            if(Math.Abs(min) < Math.Abs(max))
            {
                idx = maxid;
                x = max;
            }
            var answer = new List<(int x, int y)>();
            for (var i = 0; i < N; i++)
            {
                if(idx == i) continue;
                A[i] += x;
                answer.Add((idx + 1, i + 1));
            }
            if(A[0] >= 0)
            {
                for (var i = 1; i < N; i++)
                {
                    A[i] += A[i - 1];
                    answer.Add((i, i + 1));
                }
            }
            else
            {
                for (var i = N - 2; i >= 0; i--)
                {
                    A[i] += A[i + 1];
                    answer.Add((i + 2, i + 1));
                }
            }
            Console.WriteLine(answer.Count);
            Console.WriteLine(string.Join("\n", answer.Select(x => $"{x.x} {x.y}")));
            // Console.WriteLine(string.Join(" ", A));
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
