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
            var K = int.Parse(Console.ReadLine());
            if (K % 2 == 0 || K % 5 == 0)
            {
                Console.WriteLine(-1);
                return;
            }
            var n = 7L;
            var answer = 1L;
            while (n % K != 0)
            {
                n *= 10;
                n += 7;
                n %= K;
                answer++;
            }

            Console.WriteLine(answer);
        }
    }
}
