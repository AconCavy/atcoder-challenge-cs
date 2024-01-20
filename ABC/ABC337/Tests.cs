using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"4
10 2
10 1
10 2
3 2
",
        @"Takahashi
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
5 4
4 5
2 4
1 6
7 1
3 2
",
        @"Draw
",
        TestName = "{m}-2")]
    [TestCase(
        @"4
0 0
10 10
50 50
0 100
",
        @"Aoki
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"AAABBBCCCCCCC
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"ACABABCBC
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"A
",
        @"Yes
",
        TestName = "{m}-3")]
    [TestCase(
        @"ABBBBBBBBBBBBBCCCCCC
",
        @"Yes
",
        TestName = "{m}-4")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6
4 1 -1 5 3 2
",
        @"3 5 4 1 2 6
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
-1 1 2 3 4 5 6 7 8 9
",
        @"1 2 3 4 5 6 7 8 9 10
",
        TestName = "{m}-2")]
    [TestCase(
        @"30
3 25 20 6 18 12 26 1 29 -1 21 17 23 9 8 30 10 15 22 27 4 13 5 11 16 24 28 2 19 7
",
        @"10 17 12 6 4 21 11 24 26 7 30 16 25 2 28 27 20 3 1 8 15 18 5 23 13 22 19 29 9 14
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4 3
xo.x
..o.
xx.o
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 2 3
.o
.o
.o
.o
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 3 3
x..
..x
.x.
",
        @"-1
",
        TestName = "{m}-3")]
    [TestCase(
        @"10 12 6
......xo.o..
x...x.....o.
x...........
..o...x.....
.....oo.....
o.........x.
ox.oox.xx..x
....o...oox.
..o.....x.x.
...o........
",
        @"3
",
        TestName = "{m}-4")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

}
