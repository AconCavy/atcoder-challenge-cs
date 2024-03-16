using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"<====>
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"==>
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"<>>
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
        @"27
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"-13
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"40
",
        @"4
",
        TestName = "{m}-3")]
    [TestCase(
        @"-20
",
        @"-2
",
        TestName = "{m}-4")]
    [TestCase(
        @"123456789123456789
",
        @"12345678912345679
",
        TestName = "{m}-5")]
    [TestCase(
        @"-200000001",
        @"-20000000",
        TestName = "{m}-6")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"abc
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"aaaaa
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"aaaab",
        @"5",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 5 5
1 1
3 3
4 4
2 3
2 5
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 1 2
2 3
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 2 2
1 1
",
        @"No
",
        TestName = "{m}-3")]
    [TestCase(
        @"5 3 3
1 1
2 2
2 2
2 2
2 2
",
        @"No
",
        TestName = "{m}-4")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 2
1 1
3 5
3 3
1 4
1 2
",
        @"10
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 1
1 10
1 10
1 10
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 1
1 1
2 2
3 3
",
        @"5
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

}
