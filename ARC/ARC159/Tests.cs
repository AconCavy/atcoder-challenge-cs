using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 2
1 1 1
1 1 0
0 1 0
4
1 2
1 4
1 6
6 3
",
            @"1
1
1
3
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 1000000000
0 0 0 0
0 0 0 0
0 0 0 0
0 0 0 0
1
1 4000000000
",
            @"-1
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"15 9
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 1
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"12345678910 10987654321
",
            @"36135
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 1
2 4
10 11
7 10
",
            @"8
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
1 1
1 1
1 1
1 1
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"1
1 1000000000
",
            @"1000000000
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
