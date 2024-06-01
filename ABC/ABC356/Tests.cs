using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"5 2 3
",
        @"1 3 2 4 5
",
        TestName = "{m}-1")]
    [TestCase(
        @"7 1 1
",
        @"1 2 3 4 5 6 7
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 1 10
",
        @"10 9 8 7 6 5 4 3 2 1
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2 3
10 20 30
20 0 10
0 100 100
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 4
10 20 30 40
20 0 10 30
0 100 100 0
",
        @"No
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2 2
3 1 2 3 o
2 2 3 x
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 5 3
3 1 2 3 o
3 2 3 4 o
3 3 4 1 o
3 4 1 2 o
4 1 2 3 4 x
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"11 4 9
10 1 2 3 4 5 6 7 8 9 10 o
11 1 2 3 4 5 6 7 8 9 10 11 o
10 11 10 9 8 7 6 5 4 3 2 x
10 11 9 1 4 3 7 5 6 2 10 x
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
        @"4 3
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"0 0
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"1152921504606846975 1152921504606846975
",
        @"499791890
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
3 1 4
",
        @"8
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
2 7 1 8 2 8
",
        @"53
",
        TestName = "{m}-2")]
    [TestCase(
        @"12
3 31 314 3141 31415 314159 2 27 271 2718 27182 271828
",
        @"592622
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
