using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            // 6 5 
            //   4 1
            //     2 3
            // Console.WriteLine(654123);
            
            // 6
            // 5 4 2 3
            //       1
            Console.WriteLine(654231);

            // 6
            // 5 4 2
            //     1 3
            // Console.WriteLine(654213);

            // 6 5 1
            //     4 2 3
            // Console.WriteLine(651423);
        }
    }
}
