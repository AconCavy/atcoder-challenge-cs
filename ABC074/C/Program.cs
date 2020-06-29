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
            var ABCDEF = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A = ABCDEF[0];
            var B = ABCDEF[1];
            var C = ABCDEF[2];
            var D = ABCDEF[3];
            var E = ABCDEF[4];
            var F = ABCDEF[5];

            var answerVolume = 100 * A;
            var answerSugar = 0;
            double max = 0;

            for (var i = 0; 100 * A * i <= F; i++)
            {
                for (var j = 0; 100 * A * i + 100 * B * j <= F; j++)
                {
                    var water = 100 * (A * i + B * j);
                    for (var k = 0; water + C * k <= F; k++)
                    {
                        for (var l = 0; water + C * k + D * l <= F; l++)
                        {
                            var sugar = C * k + D * l;
                            if (100 * sugar <= E * water)
                            {
                                var tmp = (double)(100 * sugar) / (water + sugar);
                                if (tmp > max)
                                {
                                    max = tmp;
                                    answerVolume = water + sugar;
                                    answerSugar = sugar;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{answerVolume} {answerSugar}");
        }
    }
}
