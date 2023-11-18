using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"ABC
",
        @"A B C
",
        TestName = "{m}-1")]
    [TestCase(
        @"ZZZZZZZ
",
        @"Z Z Z Z Z Z Z
",
        TestName = "{m}-2")]
    [TestCase(
        @"OOXXOO
",
        @"O O X X O O
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
2 1 3 3 2
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
4 3 2 1
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"8
22 22 18 16 22 18 18 22
",
        @"18
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6
aaabaa
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
x
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"12
ssskkyskkkky
",
        @"8
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 7
1 2 2 3 1 3 3
",
        @"1
1
2
2
1
1
3
",
        TestName = "{m}-1")]
    [TestCase(
        @"100 5
100 90 80 70 60
",
        @"100
90
80
70
60
",
        TestName = "{m}-2")]
    [TestCase(
        @"9 8
8 8 2 2 8 8 2 2
",
        @"8
8
8
2
8
8
8
2
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"7 3
ABCBABC
ABC
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"7 3
ABBCABC
ABC
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"12 2
XYXXYXXYYYXY
XY
",
        @"Yes
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(4000)]
    [TestCase(
        @"6 5
1 1 1 2 2 3
1 2
6 4
5 1
3 6
4 6
",
        @"1
2
1
1
3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 3
2 4 2 4 2
3 1
2 5
3 2
",
        @"1
2
0
",
        TestName = "{m}-2")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
