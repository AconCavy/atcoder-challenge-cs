using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"6
MFMFMF
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"9
FMFMMFMFM
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"1
F
",
            @"Yes
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"........
........
........
........
........
........
........
*.......
",
            @"a1
",
            TestName = "{m}-1")]
        [TestCase(
            @"........
........
........
........
........
.*......
........
........
",
            @"b3
",
            TestName = "{m}-2")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 5
3 1 4 1 5 9
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"6 -4
-2 -7 -1 -8 -2 -8
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"2 0
141421356 17320508
",
            @"Yes
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 7
",
            @"8
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 5
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"100000 10000000000
",
            @"10000000000
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
2 2 3
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
2 1
",
            @"2
",
            TestName = "{m}-2")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 2 1
1 1 2
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
1 2 2
1 1 2
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"5
1 2 3 2 1
3 2 2 1 1
",
            @"Yes
",
            TestName = "{m}-3")]
        [TestCase(
            @"8
1 2 3 4 5 6 7 8
7 8 5 6 4 3 1 2
",
            @"No
",
            TestName = "{m}-4")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
