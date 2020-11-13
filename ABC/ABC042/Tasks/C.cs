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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, K) = (NK[0], NK[1]);
            var D = Console.ReadLine().Trim().Split(' ').Select(char.Parse).ToArray();
            var able = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }.Except(D).ToArray();

            bool CheckDigit(int n)
            {
                var ret = true;
                var x = n.ToString().ToCharArray();
                foreach (var i in x)
                {
                    ret &= able.Contains(i);
                }
                return ret;
            }

            var answer = N;
            while (!CheckDigit(answer))
            {
                answer++;
            }

            Console.WriteLine(answer);

        }
    }
}