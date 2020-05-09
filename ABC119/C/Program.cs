using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var nabc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var bamboos = new int[nabc[0]];
            for (var i = 0; i < bamboos.Length; i++)
            {
                bamboos[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(Dfs(0, 0, 0, 0, nabc, bamboos));
        }

        static int Dfs(int current, int a, int b, int c, int[] nabc, int[] bamboos)
        {
            var limit = (int)Math.Pow(10, 9);
            var tmp = Math.Abs(a - nabc[1]) + Math.Abs(b - nabc[2]) + Math.Abs(c - nabc[3]) - 30;
            var abc = new int[] { a, b, c };
            if (current == nabc[0]) return (abc.Min() > 0 ? tmp : limit);

            var rets = new int[4];
            rets[0] = Dfs(current + 1, a, b, c, nabc, bamboos);
            rets[1] = Dfs(current + 1, a + bamboos[current], b, c, nabc, bamboos) + 10;
            rets[2] = Dfs(current + 1, a, b + bamboos[current], c, nabc, bamboos) + 10;
            rets[3] = Dfs(current + 1, a, b, c + bamboos[current], nabc, bamboos) + 10;
            return rets.Min();
        }
    }
}
