using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var N = Console.ReadLine();
            var answer = (N[0] == N[1] && N[1] == N[2]) || (N[1] == N[2] && N[2] == N[3]);
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
