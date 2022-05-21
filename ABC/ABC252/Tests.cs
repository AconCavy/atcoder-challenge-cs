using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"97
",
            @"a
")]
        [TestCase(
            @"122
",
            @"z
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
6 8 10 7 10
2 3 4
",
            @"Yes
")]
        [TestCase(
            @"5 2
100 100 100 1 1
5 4
",
            @"No
")]
        [TestCase(
            @"2 1
100 1
2
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1937458062
8124690357
2385760149
",
            @"6
")]
        [TestCase(
            @"5
0123456789
0123456789
0123456789
0123456789
0123456789
",
            @"40
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
3 1 4 1
",
            @"2
")]
        [TestCase(
            @"10
99999 99998 99997 99996 99995 99994 99993 99992 99991 99990
",
            @"120
")]
        [TestCase(
            @"15
3 1 4 1 5 9 2 6 5 3 5 8 9 7 9
",
            @"355
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
1 2 1
2 3 2
1 3 10
",
            @"1 2
")]
        [TestCase(
            @"4 6
1 2 1
1 3 1
1 4 1
2 3 1
2 4 1
3 4 1
",
            @"1 2 3
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
