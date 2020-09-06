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
            var max = 0;
            var second = 0;
            var ai = new int[n];
            for (var i = 0; i < n; i++)
            {
                var a = int.Parse(Console.ReadLine());
                ai[i] = a;
                if (max <= a)
                {
                    second = max;
                    max = a;
                }
                else
                {
                    second = Math.Max(second, a);
                }
            }
            for (var i = 0; i < ai.Length; i++)
            {
                if (ai[i] == max) Console.WriteLine(second);
                else Console.WriteLine(max);
            }
        }
    }
}
