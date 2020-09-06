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
            var n = int.Parse(Console.ReadLine());
            var answer = "";
            while (n != 0)
            {
                if (n % 2 != 0)
                {
                    n = (n - 1) / -2;
                    answer = "1" + answer;
                }
                else
                {
                    n /= -2;
                    answer = "0" + answer;
                }
            }
            if (answer == "") answer = "0";
            Console.WriteLine(answer);
        }
    }
}
