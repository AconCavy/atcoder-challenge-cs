using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public class Program
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
            var t = int.Parse(Console.ReadLine());
            for (var i = 0; i < t; i++)
            {
                var nabcd = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                var n = nabcd[0];
                var a = nabcd[1];
                var b = nabcd[2];
                var c = nabcd[3];
                var d = nabcd[4];

                var memo = new Dictionary<long, long>();
                memo[0] = 0;
                memo[1] = d;
                long Dfs(long x)
                {
                    if (memo.ContainsKey(x)) return memo[x];
                    var l2 = (x / 2) * 2;
                    var r2 = ((x + 1) / 2) * 2;
                    var l3 = (x / 3) * 3;
                    var r3 = ((x + 2) / 3) * 3;
                    var l5 = (x / 5) * 5;
                    var r5 = ((x + 4) / 5) * 5;
                    var tmp = (long)Math.Pow(10, 18);
                    if (x < tmp / d) tmp = x * d;
                    tmp = Math.Min(tmp, Math.Abs(l2 - x) * d + a + Dfs(l2 / 2));
                    tmp = Math.Min(tmp, Math.Abs(r2 - x) * d + a + Dfs(r2 / 2));
                    tmp = Math.Min(tmp, Math.Abs(l3 - x) * d + b + Dfs(l3 / 3));
                    tmp = Math.Min(tmp, Math.Abs(r3 - x) * d + b + Dfs(r3 / 3));
                    tmp = Math.Min(tmp, Math.Abs(l5 - x) * d + c + Dfs(l5 / 5));
                    tmp = Math.Min(tmp, Math.Abs(r5 - x) * d + c + Dfs(r5 / 5));
                    return memo[x] = tmp;
                }
                Console.WriteLine(Dfs(n));

                // long Dfs(long coins, long current)
                // {
                //     if (current < 0) return long.MaxValue - 1;
                //     if (current >= n) return coins + (current - n) * d;
                //     if (current == 0)
                //     {
                //         current++;
                //         coins += d;
                //     }

                //     var resA = Dfs(coins + a, current * 2);
                //     var resB = Dfs(coins + b, current * 3);
                //     var resC = Dfs(coins + c, current * 5);
                //     var resD = Dfs(coins + d, current + 1);
                //     var tmp = Math.Min(Math.Min(resA, resB), Math.Min(resC, resD));
                //     return tmp;
                // }
                // Console.WriteLine(Dfs(0, 0));
            }
        }
    }
}
