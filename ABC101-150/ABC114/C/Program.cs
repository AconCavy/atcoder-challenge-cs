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
            var limit = long.Parse(Console.ReadLine());
            Console.WriteLine(Dfs("", limit));
        }

        static int Dfs(string n, long limit)
        {
            if (!string.IsNullOrEmpty(n) && long.Parse(n) > limit) return 0;
            var count = "753".Count(x => n.Contains(x)) == 3 ? 1 : 0;
            count += Dfs(n + '7', limit);
            count += Dfs(n + '5', limit);
            count += Dfs(n + '3', limit);
            return count;
        }
    }
}
