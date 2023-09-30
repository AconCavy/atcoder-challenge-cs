using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"8
ABABCABC
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
ACB
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"20
BBAAABBACAACABCBABAB
",
        @"13
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 7
abc
abcdefg
",
        @"1
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 4
abc
aabc
",
        @"2
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 3
abc
xyz
",
        @"3
",
        TestName = "{m}-3")]
    [TestCase(
        @"3 3
aaa
aaa
",
        @"0
",
        TestName = "{m}-4")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2
2 3
",
        @"1
0
0
",
        TestName = "{m}-1")]
    [TestCase(
        @"8 5
1 3 4 7 8
",
        @"0
1
0
0
2
1
0
0
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"....
###.
.#..
....
....
.###
.##.
....
..#.
.##.
.##.
.##.
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"###.
#.#.
##..
....
....
..#.
....
....
####
##..
#...
#...
",
        @"Yes
",
        TestName = "{m}-2")]
    [TestCase(
        @"##..
#..#
####
....
....
##..
.##.
....
.#..
.#..
.#..
.#..
",
        @"No
",
        TestName = "{m}-3")]
    [TestCase(
        @"....
..#.
....
....
....
..#.
....
....
....
..#.
....
....
",
        @"No
",
        TestName = "{m}-4")]
    [TestCase(
        @"....
####
#...
#...
....
####
...#
..##
....
..##
..#.
..##
",
        @"No
",
        TestName = "{m}-5")]
    [TestCase(
        @"###.
.##.
..#.
.###
....
...#
..##
...#
....
#...
#...
#...
",
        @"Yes
",
        TestName = "{m}-6")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 3 5
5 3 0 2
3 1 2 3
3 2 4 0
1 0 1 4
",
        @"9
",
        TestName = "{m}-1")]
    [TestCase(
        @"7 3 5
85 1 0 1
37 1 1 0
38 2 0 0
45 0 2 2
67 1 1 0
12 2 2 0
94 2 2 1
",
        @"-1
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"7 6
1101110
2 1 7
2 2 4
1 3 6
2 5 6
1 4 7
2 1 7
",
        @"3
1
0
7
",
        TestName = "{m}-1")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
