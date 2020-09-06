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
            var s = Console.ReadLine();
            var k = long.Parse(Console.ReadLine());

            var count = 0;
            var left = 0;
            var right = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == s[0]) left++;
                else break;
            }
            if (left == s.Length)
            {
                Console.WriteLine(s.Length * k / 2);
                return;
            }

            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == s[0]) right++;
                else break;
            }

            var tmp = 1;
            var prev = s[0];
            for (var i = left; i < s.Length - right; i++)
            {
                if (s[i] == prev)
                {
                    tmp++;
                }
                else
                {
                    count += tmp / 2;
                    tmp = 1;
                }
                prev = s[i];
            }
            count += tmp / 2;
            var edge = (left + right) / 2;
            count += edge;

            Console.WriteLine(count * k - edge + left / 2 + right / 2);
        }
    }
}
