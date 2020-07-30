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
            var NL = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, L) = (NL[0], NL[1]);
            var S = new string[N].Select(x => x = Console.ReadLine()).OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join("", S));
        }
    }
}
