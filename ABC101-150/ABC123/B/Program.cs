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
            var abcde = new int[5];
            for (var i = 0; i < abcde.Length; i++)
            {
                abcde[i] = int.Parse(Console.ReadLine());
            }
            abcde = abcde.OrderByDescending(x => (x - 1) % 10).ToArray();
            var sum = 0;
            for (var i = 0; i < abcde.Length; i++)
            {
                sum += abcde[i];
                if (i < abcde.Length - 1)
                {
                    var mod = (abcde[i] % 10);
                    sum += (mod > 0 ? 10 - mod : 0);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
