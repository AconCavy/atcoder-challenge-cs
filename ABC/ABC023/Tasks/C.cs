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
            var (R, C, K) = Scanner.Scan<int, int, int>();
            var N = Scanner.Scan<int>();
            var answer = 0L;
            var row = new int[R];
            var column = new int[C];
            var candies = new (int r, int c)[N];
            for (var i = 0; i < N; i++)
            {
                var (r, c) = Scanner.Scan<int, int>();
                row[--r]++;
                column[--c]++;
                candies[i] = (r, c);
            }

            var countRow = new long[N + 1];
            for (var i = 0; i < R; i++)
            {
                countRow[row[i]]++;
            }

            var countColumn = new long[N + 1];
            for (var i = 0; i < C; i++)
            {
                countColumn[column[i]]++;
            }

            for (var i = 0; i <= K; i++)
            {
                answer += countRow[i] * countColumn[K - i];
            }

            for (var i = 0; i < N; i++)
            {
                var r = candies[i].r;
                var c = candies[i].c;
                var count = row[r] + column[c];
                if (count == K) answer--;
                if (count == K + 1) answer++;
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
