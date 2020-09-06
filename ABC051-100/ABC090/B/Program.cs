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
            var AB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0;
            for (var x = AB[0]; x <= AB[1]; x++)
            {
                var s = x.ToString();
                var isValid = true;
                for (int l = 0, r = s.Length - 1; l < r; l++, r--)
                {
                    if (s[l] != s[r])
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid) answer++;

            }
            Console.WriteLine(answer);
        }
    }
}
