using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"10
.|..*...|.
",
            @"in
",
            TestName = "{m}-1")]
        [TestCase(
            @"10
.|..|.*...
",
            @"out
",
            TestName = "{m}-2")]
        [TestCase(
            @"3
|*|
",
            @"in
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2
1 2 1 2
6 3 4 5
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 2
1 3 1 4
6 3 4 5
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"2 1000000000
1000000000 1
1 1000000000
",
            @"1
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10
o-oooo---o
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
-
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"30
-o-o-oooo-oo-o-ooooooo--oooo-o
",
            @"7
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5
1 2
2 3
3 1
3 4
4 5
2
1 0
5 2
",
            @"Yes
10100
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 5
1 2
2 3
3 1
3 4
4 5
5
1 1
2 1
3 1
4 1
5 1
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"1 0
0
",
            @"Yes
1
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"ababbaba
",
            @"8
",
            TestName = "{m}-1")]
        [TestCase(
            @"zzz
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"ppppqqppqqqpqpqppqpqqqqpppqppq
",
            @"580
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
