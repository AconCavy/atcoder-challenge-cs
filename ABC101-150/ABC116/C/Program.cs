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
            var n = int.Parse(Console.ReadLine());
            var hi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var current = new int[hi.Length];

            Console.WriteLine(Dfs(current, hi, 0, hi.Length - 1));
        }

        static int Dfs(int[] current, int[] target, int left, int right)
        {
            if (left == right) return target[left];
            if (left > right) return 0;

            var min = 101;
            for (var i = left; i <= right; i++)
            {
                min = Math.Min(min, target[i]);
            }
            if (min == 101) return 0;

            var mid = -1;
            for (var i = left; i <= right; i++)
            {
                current[i] += min;
                target[i] -= min;
                if (target[i] == 0) mid = i;
            }

            var leftValue = Dfs(current, target, left, mid - 1);
            var rightValue = Dfs(current, target, mid + 1, right);
            return min + leftValue + rightValue;
        }
    }
}
