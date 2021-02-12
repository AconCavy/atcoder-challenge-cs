using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var S = Scanner.Scan<string>();
            var T = Scanner.Scan<string>();

            var dp = new int[S.Length + 1][].Select(_ => new int[T.Length + 1]).ToArray();
            for (var i = 0; i < S.Length; i++)
            {
                for (var j = 0; j < T.Length; j++)
                {
                    if (S[i] == T[j]) dp[i + 1][j + 1] = dp[i][j] + 1;
                    else dp[i + 1][j + 1] = Math.Max(dp[i + 1][j], dp[i][j + 1]);
                }
            }

            var builder = new StringBuilder();
            var si = S.Length;
            var ti = T.Length;
            while (si > 0 || ti > 0)
            {
                var x = dp[si][ti];
                if (si > 0 && dp[si - 1][ti] == x) si--;
                else if (ti > 0 && dp[si][ti - 1] == x) ti--;
                else
                {
                    si--;
                    ti--;
                    builder.Append(S[si]);
                }
            }

            var answer = new string(builder.ToString().Reverse().ToArray());
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
