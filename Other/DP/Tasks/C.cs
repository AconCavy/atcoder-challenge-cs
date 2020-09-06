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
            var N = int.Parse(Console.ReadLine());
            var ABC = (new int[N][]).Select(x => x = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray()).ToArray();
            var dp = (new int[3][]).Select(x => x = new int[N + 1]).ToArray();

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var k1 = (j + 1) % 3;
                    var k2 = (j + 2) % 3;
                    dp[j][i + 1] = Math.Max(dp[j][i + 1], dp[k1][i] + ABC[i][k1]);
                    dp[j][i + 1] = Math.Max(dp[j][i + 1], dp[k2][i] + ABC[i][k2]);
                }
            }

            // Console.WriteLine(string.Join("\n", dp.Select(x => string.Join(" ", x))));
            var answer = 0;
            for (var i = 0; i < 3; i++)
            {
                answer = Math.Max(answer, dp[i][N]);
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
