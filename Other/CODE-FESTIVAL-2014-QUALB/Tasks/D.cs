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
            var H = new int[N].Select(_ => Scanner.Scan<int>()).ToList();
            const int inf = (int)1e9;
            H.Insert(0, inf);
            H.Add(inf);

            var L = new int[N + 2];
            var R = new int[N + 2];
            var stack = new Stack<int>();
            for (var i = 0; i < H.Count; i++)
            {
                while (stack.TryPeek(out var top) && H[top] < H[i])
                {
                    L[top] += i - stack.Pop() - 1;
                }
                stack.Push(i);
            }

            stack.Clear();
            for (var i = H.Count - 1; i >= 0; i--)
            {
                while (stack.TryPeek(out var top) && H[top] < H[i])
                {
                    R[top] += stack.Pop() - i - 1;
                }
                stack.Push(i);
            }

            for (var i = 1; i <= N; i++)
            {
                var answer = L[i] + R[i];
                Console.WriteLine(answer);
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
