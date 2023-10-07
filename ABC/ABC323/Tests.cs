using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"1001000000001010
",
        @"No
",
        TestName = "{m}-1")]
    [TestCase(
        @"1010100000101000
",
        @"Yes
",
        TestName = "{m}-2")]
    [TestCase(
        @"1111111111111111
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
        @"3
-xx
o-x
oo-
",
        @"3 2 1
",
        TestName = "{m}-1")]
    [TestCase(
        @"7
-oxoxox
x-xxxox
oo-xoox
xoo-ooo
ooxx-ox
xxxxx-x
oooxoo-
",
        @"4 7 3 1 5 2 6
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4
1000 500 700 2000
xxxo
ooxx
oxox
",
        @"0
1
1
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 5
1000 1500 2000 2000 2500
xxxxx
oxxxx
xxxxx
oxxxx
oxxxx
",
        @"1
1
1
1
0
",
        TestName = "{m}-2")]
    [TestCase(
        @"7 8
500 500 500 500 500 500 500 500
xxxxxxxx
oxxxxxxx
ooxxxxxx
oooxxxxx
ooooxxxx
oooooxxx
ooooooxx
",
        @"7
6
5
4
3
2
0
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
3 3
5 1
6 1
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
1 1
2 1
3 1
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"1
1000000000 1000000000
",
        @"13
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 6
3 5 6
",
        @"369720131
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 0
1 2 1 2 1
",
        @"598946612
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 10000
1 2 3 4 5
",
        @"586965467
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
