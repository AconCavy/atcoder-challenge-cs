using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1 2 1 2 1
",
            @"Yes
")]
        [TestCase(
            @"12 12 11 1 2
",
            @"No
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 2
",
            @"2
")]
        [TestCase(
            @"10
1 2 3 4 5 6 7 8 9
",
            @"9
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3
",
            @"1 2
1 3
2 3
")]
        [TestCase(
            @"3 5
",
            @"1 2 3
1 2 4
1 2 5
1 3 4
1 3 5
1 4 5
2 3 4
2 3 5
2 4 5
3 4 5
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4 3
5 5 0 6 3
",
            @"14
")]
        [TestCase(
            @"4 10 10
1 2 3 4
",
            @"10
")]
        [TestCase(
            @"10 -5 -3
9 -6 10 -1 2 10 -1 7 -15 5
",
            @"-58
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 1
",
            @"4
")]
        [TestCase(
            @"5
3 1 2 1
",
            @"332748122
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
2 5
6 5
2 1
7 9
",
            @"15
")]
        [TestCase(
            @"3
1 1 1
1 1 1
1 1 1
1 1 1
1 1 1
1 1 1
1 1 1
1 1 1
",
            @"4
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
