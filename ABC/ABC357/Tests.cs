using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"5 10
2 3 2 5 3
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 10
2 3 2 3 5
",
        @"4
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 5
1
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
        @"AtCoder
",
        @"atcoder
",
        TestName = "{m}-1")]
    [TestCase(
        @"SunTORY
",
        @"SUNTORY
",
        TestName = "{m}-2")]
    [TestCase(
        @"a
",
        @"a
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"1
",
        @"###
#.#
###
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
",
        @"#########
#.##.##.#
#########
###...###
#.#...#.#
###...###
#########
#.##.##.#
#########
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
",
        @"55555
",
        TestName = "{m}-1")]
    [TestCase(
        @"9
",
        @"1755646
",
        TestName = "{m}-2")]
    [TestCase(
        @"10000000000
",
        @"468086693
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
2 1 1 4
",
        @"8
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
2 4 3 1 2
",
        @"14
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
6 10 4 1 5 9 8 6 5 1
",
        @"41
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
