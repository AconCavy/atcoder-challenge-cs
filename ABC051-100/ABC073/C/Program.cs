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
            var N = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < N; i++)
            {
                var A = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(A)) dict[A]++;
                else dict[A] = 1;
            }
            Console.WriteLine(dict.Count(x => x.Value % 2 == 1));
        }
    }
}
