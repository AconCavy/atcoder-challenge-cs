using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4
3 5
2 -6
-5 0
314159265 123456789
",
            @"8
-4
-5
437616054
",
            TestName = "{m}-1")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
abc
aaaaa
xyz
a
def
",
            @"aaaaa
abc
xyz
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 4
z
zyx
zzz
rbg
",
            @"rbg
z
zyx
zzz
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 1
abc
arc
agc
",
            @"abc
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 7
1 2
1 3
2 3
4 2
6 5
4 6
4 5
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 2
1 2
3 4
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 3
1 2
1 3
2 3
",
            @"1
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7 3
3 -1 1 -2 2 0 5
2
1 6
2 7
",
            @"Yes
No
",
            TestName = "{m}-1")]
        [TestCase(
            @"20 4
-19 -66 -99 16 18 33 32 28 26 11 12 0 -16 4 21 21 37 17 55 -19
5
13 16
4 11
3 12
13 18
4 10
",
            @"No
Yes
No
Yes
No
",
            TestName = "{m}-2")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 2
3 1 4 1 5
9 2 6 5 3
3 5
",
            @"17
",
            TestName = "{m}-1")]
        [TestCase(
            @"20 8
29 27 79 27 30 4 93 89 44 88 70 75 96 3 78 39 97 12 53 62
32 38 84 49 93 53 26 13 25 2 76 32 42 34 18 77 14 67 88 12
1 3 4 5 8 14 16 20
",
            @"533
",
            TestName = "{m}-2")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
