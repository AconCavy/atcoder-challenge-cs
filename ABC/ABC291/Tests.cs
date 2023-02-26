using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"aBc
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"xxxxxxXxxx
",
            @"7
",
            TestName = "{m}-2")]
        [TestCase(
            @"Zz
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
            @"1
10 100 20 50 30
",
            @"33.333333333333336
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
3 3 3 4 5 6 7 8 99 100
",
            @"5.500000000000000
",
            TestName = "{m}-2")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output, 1e-5);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
RLURU
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"20
URDDLLUUURRRDDDDLLLL
",
            @"No
",
            TestName = "{m}-2")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 2
4 2
3 4
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
1 5
2 6
3 7
4 8
",
            @"16
",
            TestName = "{m}-2")]
        [TestCase(
            @"8
877914575 602436426
861648772 623690081
476190629 262703497
971407775 628894325
822804784 450968417
161735902 822804784
161735902 822804784
822804784 161735902
",
            @"48
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
3 1
2 3
",
            @"Yes
3 1 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 2
3 1
3 2
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"4 6
1 2
1 2
2 3
2 3
3 4
3 4
",
            @"Yes
1 2 3 4
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }


        [Timeout(2000)]
        [TestCase(
            @"5 2
11
01
11
10
00
",
            @"2 3 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"6 3
101
001
101
000
100
000
",
            @"-1 3 3 -1
",
            TestName = "{m}-2")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
