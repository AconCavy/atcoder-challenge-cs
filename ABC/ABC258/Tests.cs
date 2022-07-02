using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"63
",
            @"22:03
")]
        [TestCase(
            @"45
",
            @"21:45
")]
        [TestCase(
            @"100
",
            @"22:40
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1161
1119
7111
1811
",
            @"9786
")]
        [TestCase(
            @"10
1111111111
1111111111
1111111111
1111111111
1111111111
1111111111
1111111111
1111111111
1111111111
1111111111
",
            @"1111111111
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
abc
2 2
1 1
2 2
",
            @"b
a
")]
        [TestCase(
            @"10 8
dsuccxulnl
2 4
2 7
1 2
2 7
1 1
1 2
1 3
2 5
",
            @"c
u
c
u
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
3 4
2 3
4 2
",
            @"18
")]
        [TestCase(
            @"10 1000000000
3 3
1 6
4 7
1 8
5 7
9 9
2 4
6 4
5 1
3 1
",
            @"1000000076
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2 5
3 4 1
1
2
",
            @"2
3
")]
        [TestCase(
            @"10 5 20
5 8 5 9 8 7 4 4 8 2
1
1000
1000000
1000000000
1000000000000
",
            @"4
5
5
5
5
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
