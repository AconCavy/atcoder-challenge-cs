using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"5 2
2 5 6 7 10
",
        @"1 3 5
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 1
3 4 7
",
        @"3 4 7
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 10
50 51 54 60 65
",
        @"5 6
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"yay
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"aababc
",
        @"17
",
        TestName = "{m}-2")]
    [TestCase(
        @"abracadabra
",
        @"54
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2 5
1 2 9
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 5 10
10 15
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"4 347 347
347 700 705 710
",
        @"Yes
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4 7
",
        @"28 27
",
        TestName = "{m}-1")]
    [TestCase(
        @"34 56 998244353
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"39 47 530423800524412070
",
        @"540431255696862041 10008854347644927
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4
1 3 3 2
",
        @"6 2 2
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 6
1 2 3 2 4 2
",
        @"15 9 12 7
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
