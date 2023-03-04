using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"abc
",
            @"ABC
",
            TestName = "{m}-1")]
        [TestCase(
            @"a
",
            @"A
",
            TestName = "{m}-2")]
        [TestCase(
            @"abcdefghjiklnmoqprstvuwxyz
",
            @"ABCDEFGHJIKLNMOQPRSTVUWXYZ
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 9
3 1
3 2
1 2
2 1
3 1
3 2
1 2
3 2
3 3
",
            @"No
No
Yes
No
Yes
No
",
            TestName = "{m}-1")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
",
            @"8
",
            TestName = "{m}-1")]
        [TestCase(
            @"292
",
            @"10886
",
            TestName = "{m}-2")]
        [TestCase(
            @"19876
",
            @"2219958
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
2 3
1 1
2 3
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 5
1 2
2 3
3 4
3 5
1 5
",
            @"Yes
",
            TestName = "{m}-2")]
        [TestCase(
            @"13 16
7 9
7 11
3 8
1 13
11 11
6 11
8 13
2 11
3 3
8 12
9 11
1 11
5 13
3 12
6 9
1 10
",
            @"No
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 3
2 4
3 1
4 3
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"292 0
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 8
1 2
2 1
1 3
3 1
1 4
4 1
1 5
5 1
",
            @"12
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
