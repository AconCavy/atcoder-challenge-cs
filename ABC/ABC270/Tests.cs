using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1 2
",
            @"3
")]
        [TestCase(
            @"5 3
",
            @"7
")]
        [TestCase(
            @"0 0
",
            @"0
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 -10 1
",
            @"10
")]
        [TestCase(
            @"20 10 -10
",
            @"40
")]
        [TestCase(
            @"100 1 1000
",
            @"-1
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 2 5
1 2
1 3
3 4
3 5
",
            @"2 1 3 5
")]
        [TestCase(
            @"6 1 2
3 1
2 5
1 2
4 1
2 6
",
            @"1 2
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 2
1 4
",
            @"5
")]
        [TestCase(
            @"11 4
1 2 3 6
",
            @"8
")]
        [TestCase(
            @"10000 10
1 2 4 8 16 32 64 128 256 512
",
            @"5136
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
1 3 0
",
            @"0 1 0
")]
        [TestCase(
            @"2 1000000000000
1000000000000 1000000000000
",
            @"500000000000 500000000000
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
