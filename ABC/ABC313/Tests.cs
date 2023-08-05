using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4
5 15 2 10
",
            @"11
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
15 5 2 10
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"3
100 100 100
",
            @"1
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
1 2
2 3
",
            @"1
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 2
1 3
2 3
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"6 6
1 6
6 5
6 2
2 3
4 3
4 2
",
            @"-1
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
4 7 3 7
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
313
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"10
999999997 999999999 4 3 2 4 999999990 8 999999991 999999993
",
            @"2499999974
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
313
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"9
123456789
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"2
11
",
            @"1
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
