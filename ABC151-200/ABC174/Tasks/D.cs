using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var C = Console.ReadLine().ToCharArray();
            var R = C.Count(x => x == 'R');
            var answer = C.Take(R).Count(x => x == 'W');

            Console.WriteLine(answer);
        }
    }
}
