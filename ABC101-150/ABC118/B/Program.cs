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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var likes = new int[nm[1]];
            for (var i = 0; i < nm[0]; i++)
            {
                var ka = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (var j = 1; j < ka.Length; j++)
                {
                    likes[ka[j] - 1]++;
                }
            }
            Console.WriteLine(likes.Where(x => x == nm[0]).Count());
        }
    }
}
