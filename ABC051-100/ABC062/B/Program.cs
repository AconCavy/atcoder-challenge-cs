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
            var HW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (H, W) = (HW[0], HW[1]);
            var A = new string[H].Select(x => x = Console.ReadLine()).ToArray();
            var wall = string.Join("", Enumerable.Repeat("#", W + 2));
            Console.WriteLine(wall);
            for (var i = 0; i < H; i++)
            {
                Console.WriteLine($"#{A[i]}#");
            }
            Console.WriteLine(wall);
        }
    }
}
