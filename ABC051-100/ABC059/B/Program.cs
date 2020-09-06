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
            var A = Console.ReadLine();
            var B = Console.ReadLine();
            if (A.Length > B.Length)
            {
                Console.WriteLine("GREATER");
            }
            else if (A.Length < B.Length)
            {
                Console.WriteLine("LESS");
            }
            else
            {
                var answer = "EQUAL";
                for (var i = 0; i < A.Length; i++)
                {
                    if (A[i] == B[i]) continue;
                    if (A[i] > B[i]) answer = "GREATER";
                    if (A[i] < B[i]) answer = "LESS";
                    break;
                }
                Console.WriteLine(answer);
            }
        }
    }
}
