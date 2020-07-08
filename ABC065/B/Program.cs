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
            var N = int.Parse(Console.ReadLine());
            var A = new int[N].Select(x => x = int.Parse(Console.ReadLine())).ToArray();
            var ok = false;
            var count = 1;
            var next = A[0];
            var checker = new bool[N + 1];
            checker[1] = true;
            while (!checker[next])
            {
                if (next == 2)
                {
                    ok = true;
                    break;
                }
                checker[next] = true;
                next = A[next - 1];
                count++;
            }
            Console.WriteLine(ok ? count : -1);
        }
    }
}
