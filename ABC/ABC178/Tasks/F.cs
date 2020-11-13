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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var B = Scanner.ScanEnumerable<int>().ToArray();
            var dictA = new Dictionary<int, int>();
            var dictB = new Dictionary<int, int>();
            for (var i = 0; i < N; i++)
            {
                if (!dictA.ContainsKey(A[i])) dictA[A[i]] = 0;
                dictA[A[i]]++;
                if (!dictB.ContainsKey(B[i])) dictB[B[i]] = 0;
                dictB[B[i]]++;
            }

            var (keyA, keyB, maxA, maxB) = (0, 0, 0, 0);
            foreach (var a in dictA)
            {
                if (maxA >= a.Value) continue;
                maxA = a.Value;
                keyA = a.Key;
            }

            foreach (var b in dictB)
            {
                if (maxB >= b.Value) continue;
                maxB = b.Value;
                keyB = b.Key;
            }

            if (keyA == keyB && maxA + maxB > N)
            {
                Console.WriteLine("No");
                return;
            }

            var answer = new int[N];
            var m = maxA - 1;
            var index = 0;
            while (index < N)
            {
                if (m >= N)
                {
                    Console.WriteLine("No");
                    return;
                }
                if (A[(m + index) % N] == B[index])
                {
                    m++;
                    index = 0;
                }
                else index++;
            }
            for (var i = 0; i < N; i++)
            {
                answer[(m + i) % N] = B[i];
            }
            Console.WriteLine("Yes");
            Console.WriteLine(string.Join(" ", answer));
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
