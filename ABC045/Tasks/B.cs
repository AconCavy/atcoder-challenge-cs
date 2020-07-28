using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var SA = Console.ReadLine();
            var SB = Console.ReadLine();
            var SC = Console.ReadLine();
            var ia = 0;
            var ib = 0;
            var ic = 0;
            var answer = 'a';
            var next = 'a';
            while (true)
            {
                if (next == 'a' && ia == SA.Length) break;
                else if (next == 'b' && ib == SB.Length) break;
                else if (next == 'c' && ic == SC.Length) break;

                switch (next)
                {
                    case 'a': next = SA[ia++]; break;
                    case 'b': next = SB[ib++]; break;
                    case 'c': next = SC[ic++]; break;
                }

                answer = Char.ToUpper(next);
            }
            Console.WriteLine(answer);
        }
    }
}
