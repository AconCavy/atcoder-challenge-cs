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
            var x = int.Parse(Console.ReadLine());
            var answer = 1;
            var i = (int)Math.Sqrt(x);
            while (i > 1)
            {
                var tmp = i * i;
                while (tmp <= x)
                {
                    answer = Math.Max(answer, tmp);
                    tmp *= i;
                }
                i--;
            }
            Console.WriteLine(answer);
        }
    }
}
