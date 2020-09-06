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
            var st = Console.ReadLine().Trim().Split(' ');
            var chars = new char[n * 2];
            for (var i = 0; i < n; i++)
            {
                var index = 2 * i;
                chars[index] = st[0][i];
                chars[index + 1] = st[1][i];
            }
            Console.WriteLine(new string(chars));
        }
    }
}
