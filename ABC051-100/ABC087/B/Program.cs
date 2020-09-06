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
            var A = int.Parse(Console.ReadLine());
            var B = int.Parse(Console.ReadLine());
            var C = int.Parse(Console.ReadLine());
            var X = int.Parse(Console.ReadLine());
            var answer = 0;
            for (var a = 0; a <= A; a++)
            {
                for (var b = 0; b <= B; b++)
                {
                    for (var c = 0; c <= C; c++)
                    {
                        var val = 500 * a + 100 * b + 50 * c;
                        if (val == X) answer++;
                        if (val > X) break;
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }
}
