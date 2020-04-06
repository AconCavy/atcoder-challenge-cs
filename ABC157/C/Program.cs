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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var tmp = new int[nm[0]];
            var isValid = true;

            for (var i = 0; i < nm[1]; i++)
            {
                var sc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var isHeadZero = sc[0] == 1 && sc[1] == 0;
                var isDifferent = tmp[sc[0] - 1] != 0 && tmp[sc[0] - 1] != sc[1];
                if (isHeadZero || isDifferent)
                {
                    isValid = false;
                    break;
                }
                tmp[sc[0] - 1] = sc[1];
            }

            var isZero = nm[0] == 1 && tmp[0] == 0;
            if (isValid && nm[0] != 1 && tmp[0] == 0) tmp[0] = 1;
            var result = int.Parse(string.Join("", tmp));
            Console.WriteLine(isValid ? result : -1);
        }
    }
}
