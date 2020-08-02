using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var S = Console.ReadLine();
            var scales = new[] { "Do", "Do", "Re", "Re", "Mi", "Fa", "Fa", "So", "So", "La", "La", "Si" };
            var baseScales = "WBWBWWBWBWBWWBWBWWBWBWBWWBWBWWBWBWBW";
            var index = baseScales.IndexOf(S) % scales.Length;
            Console.WriteLine(scales[index]);
        }
    }
}
