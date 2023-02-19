using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 2
10 20 30
1 3
",
            @"40
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 1
1 1 1 100
4
",
            @"100
",
            TestName = "{m}-2")]
        [TestCase(
            @"8 4
22 75 26 45 72 81 47 29
4 6 7 8
",
            @"202
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 3
oxxoxooxox
",
            @"oxxoxoxxxx
",
            TestName = "{m}-1")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7 3
2 0 2 3 2 1 9
",
            @"3
",
            TestName = "{m}-1")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"9
4 2 1
4 2 2
4 2 3
4 2 4
5 8 1
5 8 2
5 8 3
5 8 4
5 8 5
",
            @"0
2
1
3
0
3
1
4
2
",
            TestName = "{m}-1")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
5 2 1 2 2
",
            @"9
",
            TestName = "{m}-1")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
