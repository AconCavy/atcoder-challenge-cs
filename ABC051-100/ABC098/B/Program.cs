using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var s = Console.ReadLine();
            var answer = 0;
            for (var i = 1; i < s.Length - 1; i++)
            {
                var left = new Dictionary<char, int>();
                var right = new Dictionary<char, int>();
                for (var j = 0; j < i; j++)
                {
                    left[s[j]] = 0;
                }
                for (var j = i; j < s.Length; j++)
                {
                    right[s[j]] = 0;
                }
                var count = 0;
                foreach (var c in left.Keys)
                {
                    if (right.ContainsKey(c)) count++;
                }
                answer = Math.Max(answer, count);
            }
            Console.WriteLine(answer);
        }
    }
}
