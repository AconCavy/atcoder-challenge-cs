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
            var S = Console.ReadLine();


            var answer = Enumerable.Repeat('-', N).ToArray();

            Func<char[], int, bool> check = (char[] array, int current) =>
            {
                var left = (current - 1 + N) % N;
                var right = (current + 1) % N;
                var isEmpty = array[right] == '-';

                if (array[current] == 'S')
                {
                    if (isEmpty)
                    {
                        if (S[current] == 'o') array[right] = array[left];
                        else array[right] = array[left] == 'S' ? 'W' : 'S';
                        return true;
                    }
                    else
                    {
                        var same = array[left] == array[right];
                        if (S[current] == 'o') return same;
                        else return !same;
                    }
                }
                else
                {
                    if (isEmpty)
                    {
                        if (S[current] == 'o') array[right] = array[left] == 'S' ? 'W' : 'S';
                        else array[right] = array[left];
                        return true;
                    }
                    else
                    {
                        var same = array[left] == array[right];
                        if (S[current] == 'o') return !same;
                        else return same;
                    }
                }
            };

            var ok = true;
            for (var bit = 0; bit < 1 << 3; bit++)
            {
                answer = Enumerable.Repeat('-', N).ToArray();
                answer[0] = (bit >> 1 & 1) == 1 ? 'S' : 'W';
                answer[1] = (bit >> 0 & 1) == 1 ? 'S' : 'W';
                answer[N - 1] = (bit >> 2 & 1) == 1 ? 'S' : 'W';
                ok = true;
                for (var i = 0; i < N; i++)
                {
                    ok = check(answer, i);
                    if (!ok) break;
                }
                if (ok) break;
            }

            Console.WriteLine(ok ? new string(answer) : "-1");
        }
    }
}
