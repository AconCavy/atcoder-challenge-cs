using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
alice 31
bob 41
carol 5
dave 92
ellen 65
",
            @"carol
dave
ellen
alice
bob
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
takahashi 1000000000
aoki 999999999
",
            @"aoki
takahashi
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"20230603
",
            @"20200000
",
            TestName = "{m}-1")]
        [TestCase(
            @"0
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"304
",
            @"304
",
            TestName = "{m}-3")]
        [TestCase(
            @"500600
",
            @"500000
",
            TestName = "{m}-4")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 5
2 -1
3 1
8 8
0 5
",
            @"Yes
Yes
No
Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 1
0 0
-1000 -1000
1000 1000
",
            @"Yes
No
No
",
            TestName = "{m}-2")]
        [TestCase(
            @"9 4
3 2
6 -1
1 6
6 5
-2 -3
5 3
2 -3
2 1
2 6
",
            @"Yes
No
No
Yes
Yes
Yes
Yes
Yes
No
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7 6
5
6 1
3 1
4 2
1 5
6 2
2
2 5
2
3 4
",
            @"0 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 4
4
1 1
3 1
3 3
1 3
1
2
1
2
",
            @"1 1
",
            TestName = "{m}-2")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 6
1 2
2 3
2 3
3 1
5 4
5 5
3
1 5
2 6
4 3
4
2 5
2 6
5 6
5 4
",
            @"No
No
Yes
Yes
",
            TestName = "{m}-1")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
##.#.#
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"7
...####
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"12
####.####.##
",
            @"19
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
