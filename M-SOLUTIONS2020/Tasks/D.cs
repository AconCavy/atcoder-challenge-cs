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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var days = new List<long>();
            var prev = 201L;
            for (var i = 0; i < A.Length; i++)
            {
                if (days.Count % 2 == 0)
                {
                    var tmp = prev;
                    for (var j = i; j < A.Length; j++)
                    {
                        if (A[j] <= tmp) tmp = A[j];
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                }
                else
                {
                    var tmp = prev;
                    for (var j = i; j < A.Length; j++)
                    {
                        if (A[j] >= tmp) tmp = A[j];
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                }
                prev = A[i];
                days.Add(prev);
            }
            if (days.Count % 2 == 1) days.RemoveAt(days.Count - 1);
            var answer = 1000L;
            var stock = 0L;
            for (var i = 0; i < days.Count; i++)
            {
                if (i % 2 == 0)
                {
                    stock += answer / days[i];
                    answer -= stock * days[i];
                }
                else
                {
                    answer += stock * days[i];
                    stock = 0;
                }
            }

            Console.WriteLine(answer);

            // var N = int.Parse(Console.ReadLine());
            // var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToList();
            // A.Insert(0, 0);
            // var dp = new long[N + 1];
            // dp[1] = 1000;
            // for (var i = 2; i <= N; i++)
            // {
            //     dp[i] = dp[i - 1];
            //     for (var j = 1; j <= i - 1; j++)
            //     {
            //         var stock = dp[j] / A[j];
            //         var sum = dp[j] + (A[i] - A[j]) * stock;
            //         dp[i] = Math.Max(dp[i], sum);
            //     }
            // }
            // var answer = dp[N];
            // Console.WriteLine(answer);
        }
    }
}
