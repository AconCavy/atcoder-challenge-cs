using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"125 175 250 300 400 525 600 650
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"100 250 300 400 325 575 625 675
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"0 23 24 145 301 413 631 632
",
            @"No
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
red green blue
blue red
800 1600 2800
",
            @"5200
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 2
code queen atcoder
king queen
10 1 1
",
            @"21
",
            TestName = "{m}-2")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 3
3 1
2 2
",
            @"2 3 1
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
1 3
2 6
",
            @"1 2
",
            TestName = "{m}-2")]
        [TestCase(
            @"4
999999999 1000000000
333333333 999999999
1000000000 999999997
999999998 1000000000
",
            @"3 1 4 2
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3
sns
euk
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 2
ab
cd
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 7
skunsek
nukesnu
ukeseku
nsnnesn
uekukku
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
            @"4
1 1 0 2
MEEX
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
0 0 0
XXX
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"15
1 1 2 0 0 2 0 2 0 0 0 0 0 2 2
EXMMXXXEMEXEXMM
",
            @"13
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
4 3 1
4 4 2
2 3 1
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"10 5
9 7 1 5 2 2 5 5 7 6
7 2 7 8 2
3 2 4 1 2
",
            @"37
",
            TestName = "{m}-2")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
