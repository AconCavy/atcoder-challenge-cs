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
            var B = new int[2][];
            var C = new int[3][];
            var sum = 0;
            for (var i = 0; i < 2; i++)
            {
                B[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                sum += B[i].Sum();
            }
            for (var i = 0; i < 3; i++)
            {
                C[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                sum += C[i].Sum();
            }

            var G = new int[3][].Select(x => x = new int[3]).ToArray();
            int Dfs(int steps)
            {
                if (steps == 9)
                {
                    var score = 0;
                    for (var i = 0; i < 2; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            if (G[i][j] == G[i + 1][j]) score += B[i][j];
                        }
                    }
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 2; j++)
                        {
                            if (G[i][j] == G[i][j + 1]) score += C[i][j];
                        }
                    }

                    return score;
                }

                var min = (int)1e9;
                var max = 0;
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        if (G[i][j] == 0)
                        {
                            G[i][j] = steps % 2 == 0 ? 1 : 2;
                            var tmp = Dfs(steps + 1);
                            min = Math.Min(min, tmp);
                            max = Math.Max(max, tmp);
                            G[i][j] = 0;
                        }
                    }
                }
                return steps % 2 == 0 ? max : min;
            }

            var chokudai = Dfs(0);
            Console.WriteLine(chokudai);
            Console.WriteLine(sum - chokudai);
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
