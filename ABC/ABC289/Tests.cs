using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"01
",
            @"10
",
            TestName = "{m}-1")]
        [TestCase(
            @"1011
",
            @"0100
",
            TestName = "{m}-2")]
        [TestCase(
            @"100100001
",
            @"011011110
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
1 3 4
",
            @"2 1 5 4 3
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 0

",
            @"1 2 3 4 5
",
            TestName = "{m}-2")]
        [TestCase(
            @"10 6
1 2 3 7 8 9
",
            @"4 3 2 1 5 6 10 9 8 7
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
2
1 2
2
1 3
1
2
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 2
2
1 2
2
1 3
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"6 6
3
2 3 6
3
2 4 6
2
3 6
3
1 5 6
3
1 3 6
2
1 4
",
            @"18
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
3 4 5
4
4 5 6 8
15
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
2 3 4 5
4
3 4 5 6
8
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"4
2 5 7 8
5
2 9 10 11 19
20
",
            @"Yes
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
4 4
0 1 0 1
1 2
2 3
1 3
2 4
3 3
0 1 0
1 2
2 3
1 3
6 6
0 0 1 1 0 1
1 2
2 6
3 6
4 6
4 5
2 4
",
            @"3
-1
3
",
            TestName = "{m}-1")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
