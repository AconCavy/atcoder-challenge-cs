using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var pixels = new string[H];
            for (var i = 0; i < H; i++)
            {
                var s = Console.ReadLine();
                pixels[i] = s;
            }

            for (var i = 0; i < H; i++)
            {
                Console.WriteLine(pixels[i]);
                Console.WriteLine(pixels[i]);
            }
        }
    }
}
