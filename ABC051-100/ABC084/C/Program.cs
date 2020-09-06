using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var C = new int[N - 1];
            var S = new int[N - 1];
            var F = new int[N - 1];
            for (var i = 0; i < N - 1; i++)
            {
                var CSF = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                C[i] = CSF[0];
                S[i] = CSF[1];
                F[i] = CSF[2];
            }

            for (var i = 0; i < N; i++)
            {
                var answer = 0;
                for (var j = i; j < N - 1; j++)
                {
                    var nc = C[j];
                    var ns = S[j];
                    var nf = F[j];
                    if (answer <= ns) answer = ns;
                    else if (answer % nf != 0) answer += nf - answer % nf;
                    answer += nc;
                }
                Console.WriteLine(answer);
            }
        }
    }
}
