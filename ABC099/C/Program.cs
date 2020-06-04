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
            var answer = n;
            for (var i = 0; i <= n; i++)
            {
                var num = 0;
                var tmp = i;
                while (tmp > 0)
                {
                    num += tmp % 6;
                    tmp /= 6;
                }
                tmp = n - i;
                while (tmp > 0)
                {
                    num += tmp % 9;
                    tmp /= 9;
                }
                answer = Math.Min(answer, num);
            }

            Console.WriteLine(answer);
        }
    }
}
