using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
",
            @"8
")]
        [TestCase(
            @"30
",
            @"1073741824
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 1 3 2
",
            @"3
")]
        [TestCase(
            @"3
1 1 1
",
            @"0
")]
        [TestCase(
            @"10
2 2 4 1 1 1 4 2 2 1
",
            @"8
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4 6 3 3 7
",
            @"1
")]
        [TestCase(
            @"3 4 5 6 7 8
",
            @"0
")]
        [TestCase(
            @"5 13 10 6 13 9
",
            @"120
")]
        [TestCase(
            @"20 25 30 22 29 24
",
            @"30613
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
10 20
20 30
40 50
",
            @"10 30
40 50
")]
        [TestCase(
            @"3
10 40
30 60
20 50
",
            @"10 60
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
2 3 2
1 10 100
",
            @"10
")]
        [TestCase(
            @"8
7 3 5 5 8 4 1 2
36 49 73 38 30 85 27 45
",
            @"57
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
1 2 3
2 3
1 2 0
2 3
",
            @"15
9
")]
        [TestCase(
            @"2 1
998244353 998244353
2 1
",
            @"0
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
