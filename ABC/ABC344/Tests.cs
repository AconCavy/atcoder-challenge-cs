using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"atcoder|beginner|contest
",
        @"atcodercontest
",
        TestName = "{m}-1")]
    [TestCase(
        @"|spoiler|
",
        @"
",
        TestName = "{m}-2")]
    [TestCase(
        @"||xyz
",
        @"xyz
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
2
1
0
",
        @"0
1
2
3
",
        TestName = "{m}-1")]
    [TestCase(
        @"0
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"123
456
789
987
654
321
0
",
        @"0
321
654
987
789
456
123
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
1 2 3
2
2 4
6
1 2 4 8 16 32
4
1 5 10 50
",
        @"No
Yes
Yes
No
",
        TestName = "{m}-1")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"abcde
3
3 ab abc abcd
4 f c cd bcde
2 e de
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"abcde
3
2 ab abc
3 f c bcde
1 e
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"aaabbbbcccc
6
2 aa aaa
2 dd ddd
2 ab aabb
4 bbaa bbbc bbb bbcc
2 cc bcc
3 ccc cccc ccccc
",
        @"4
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
2 1 4 3
4
2 1
1 4 5
2 2
1 5 1
",
        @"4 5 1 3
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
3 1 4 5 9 2
7
2 5
1 3 5
1 9 7
2 9
2 3
1 2 3
2 4
",
        @"5 1 7 2 3
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(4000)]
    [TestCase(
        @"3
1 2 3
3 1 2
2 1 1
1 2
4 3
4 2
1 5 7
5 3 3
",
        @"8
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
1 1 1
1 1 1
1 1 1
1000000000 1000000000
1000000000 1000000000
1000000000 1000000000
1000000000 1000000000 1000000000
1000000000 1000000000 1000000000
",
        @"4000000004
",
        TestName = "{m}-2")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
