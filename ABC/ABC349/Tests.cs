using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"4
1 -2 -1
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
0 0
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"6
10 20 30 40 50
",
        @"-150
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"commencement
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"banana
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"ab
",
        @"Yes
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"narita
NRT
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"losangeles
LAX
",
        @"Yes
",
        TestName = "{m}-2")]
    [TestCase(
        @"snuke
RNG
",
        @"No
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 19
",
        @"5
3 4
4 8
8 16
16 18
18 19
",
        TestName = "{m}-1")]
    [TestCase(
        @"0 1024
",
        @"1
0 1024
",
        TestName = "{m}-2")]
    [TestCase(
        @"3940649673945088 11549545024454656
",
        @"8
3940649673945088 3940649673949184
3940649673949184 4503599627370496
4503599627370496 9007199254740992
9007199254740992 11258999068426240
11258999068426240 11540474045136896
11540474045136896 11549270138159104
11549270138159104 11549545016066048
11549545016066048 11549545024454656
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"0 0 0
0 1 0
0 0 0
",
        @"Takahashi
",
        TestName = "{m}-1")]
    [TestCase(
        @"-1 1 0
-4 -2 -5
-4 -1 -5
",
        @"Aoki
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 6
2 3 4 6
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 349
1 1 1 1 349
",
        @"16
",
        TestName = "{m}-2")]
    [TestCase(
        @"16 720720
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
",
        @"2688
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
