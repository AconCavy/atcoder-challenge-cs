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
            var (N, M, P, Q, R) = Scanner.Scan<int, int, int, int, int>();
            var XYZ = new (int X, int Y, long Z)[R];
            for (var i = 0; i < R; i++)
            {
                XYZ[i] = Scanner.Scan<int, int, long>();
                XYZ[i].X--;
                XYZ[i].Y--;
            }

            var answer = 0L;
            var hashset = new HashSet<int>();
            for (var bit = 0; bit < 1 << N; bit++)
            {
                hashset.Clear();
                for (var i = 0; i < N; i++)
                {
                    if ((bit >> i & 1) == 1) hashset.Add(i);
                }
                if (hashset.Count != P) continue;

                var score = new long[M];
                foreach (var xyz in XYZ)
                {
                    if (hashset.Contains(xyz.X)) score[xyz.Y] += xyz.Z;
                }

                answer = Math.Max(answer, score.OrderByDescending(x => x).Take(Q).Sum());
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
