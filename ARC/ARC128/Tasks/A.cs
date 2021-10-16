using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var delta = new long[N];
            delta[0] = A[0];
            for (var i = 1; i < N; i++)
            {
                delta[i] = A[i] - A[i - 1];
            }

            var isGold = true;
            var list = new List<int>();
            var curr = 0L;
            for (var i = 0; i < N; i++)
            {
                if (isGold)
                {
                    if (curr > A[i])
                    {
                        list.Add(i - 1);
                        isGold = !isGold;
                    }
                }
                else
                {
                    if (curr < A[i])
                    {
                        list.Add(i - 1);
                        isGold = !isGold;
                    }
                }
                curr = A[i];
            }

            var answer = new int[N];
            if (!isGold)
            {
                if (A[list[^1]] > A[N - 1])
                {
                    list.Add(N - 1);
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                }
            }

            foreach (var i in list)
            {
                answer[i] = 1;
            }

            Console.WriteLine(string.Join(" ", answer));
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
