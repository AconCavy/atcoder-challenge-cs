using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
",
            @"ABC
")]
        [TestCase(
            @"1
",
            @"A
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5
ooooo
oooxx
xxooo
oxoxo
xxxxx
",
            @"5
")]
        [TestCase(
            @"3 2
ox
xo
xx
",
            @"1
")]
        [TestCase(
            @"2 4
xxxx
oxox
",
            @"0
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4
4 2
3 1
5 2
3 2
",
            @"2
")]
        [TestCase(
            @"4 3
3 1
3 2
1 2
",
            @"0
")]
        [TestCase(
            @"9 11
4 9
9 1
8 2
8 3
9 2
8 4
6 7
4 6
7 5
4 5
7 8
",
            @"9
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 10
4 2 3 2
",
            @"20
")]
        [TestCase(
            @"20 100
29 31 68 20 83 66 23 84 69 96 41 61 83 37 52 71 18 55 40 8
",
            @"1733
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
