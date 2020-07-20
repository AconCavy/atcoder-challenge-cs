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
            var X = long.Parse(Console.ReadLine());
            var answer = 2 * (X / 11);
            if (X % 11 == 0) ;
            else if (X % 11 <= 6) answer += 1;
            else answer += 2;
            Console.WriteLine(answer);
        }
    }
}
