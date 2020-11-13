using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var (N, M) = Scanner.Scan<long, long>();
            var (X, Y) = Scanner.Scan<long, long>();
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var B = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = 0;
            var current = 0L;
            var i = 0;
            var j = 0;
            while (true)
            {
                while (i < N && current > A[i])
                {
                    i++;
                }
                if (i < N) current = A[i] + X;
                else break;

                while (j < M && current > B[j])
                {
                    j++;
                }
                if (j < M)
                {
                    current = B[j] + Y;
                    answer++;
                }
                else break;
            }

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
        }
    }
}
