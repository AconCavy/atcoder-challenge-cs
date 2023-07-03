using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"25 10 11 12
",
            @"T
",
            TestName = "{m}-1")]
        [TestCase(
            @"30 10 10 10
",
            @"F
",
            TestName = "{m}-2")]
        [TestCase(
            @"100000 1 1 1
",
            @"M
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }


        [Timeout(2000)]
        [TestCase(
            @"4
1 3 5 2
2 3 1 4
",
            @"1
2
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
1 2 3
4 5 6
",
            @"0
0
",
            TestName = "{m}-2")]
        [TestCase(
            @"7
4 8 1 7 9 5 6
3 5 1 7 8 2 6
",
            @"3
2
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
2 3
1 1
4 1
RRL
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
1 1
2 1
RR
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"10
1 3
1 4
0 0
0 2
0 4
3 1
2 4
4 2
4 4
3 3
RLRRRLRLRR
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
            @"3 2
URL
",
            @"6
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 500000000000000000
RRUU
",
            @"500000000000000000
",
            TestName = "{m}-2")]
        [TestCase(
            @"30 123456789
LRULURLURLULULRURRLRULRRRUURRU
",
            @"126419752371
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
1 2 2
2 3 3
1 3 6
",
            @"1
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 4
1 3 3
2 3 9
3 5 3
4 5 3
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 10
1 2 71
1 3 9
1 4 82
1 5 64
2 3 22
2 4 99
2 5 1
3 4 24
3 5 18
4 5 10
",
            @"5
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 1 2
2
1
",
            @"221832079
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 3 2
1
1
1
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 3 10
499122176
499122175
1
",
            @"335346748
",
            TestName = "{m}-3")]
        [TestCase(
            @"10 8 15
1
1
1
1
1
1
1
1
1
1
",
            @"755239064
",
            TestName = "{m}-4")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
