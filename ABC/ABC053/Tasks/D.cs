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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var dict = new Dictionary<int, int>();
            foreach (var a in A)
            {
                if (dict.ContainsKey(a)) dict[a]++;
                else dict[a] = 1;
            }
            var over = 0;
            foreach (var x in dict)
            {
                over += x.Value - 1;
            }
            var answer = dict.Keys.Count();
            if (over % 2 == 1) answer--;
            Console.WriteLine(answer);
        }
    }
}
