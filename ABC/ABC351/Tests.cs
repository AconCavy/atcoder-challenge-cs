using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"0 1 0 1 2 2 0 0 1
1 1 0 0 0 0 1 0
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0
",
        @"1
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
abc
def
ghi
abc
bef
ghi
",
        @"2 1
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
f
q
",
        @"1 1
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
eixfumagit
vtophbepfe
pxbfgsqcug
ugpugtsxzq
bvfhxyehfk
uqyfwtmglr
jaitenfqiq
acwvufpfvv
jhaddglpva
aacxsyqvoj
eixfumagit
vtophbepfe
pxbfgsqcug
ugpugtsxzq
bvfhxyehok
uqyfwtmglr
jaitenfqiq
acwvufpfvv
jhaddglpva
aacxsyqvoj
",
        @"5 9
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"7
2 1 1 3 5 3 3
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
0 0 0 1 2
",
        @"4
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 5
.#...
.....
.#..#
",
        @"9
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 3
..#
#..
..#
",
        @"1
",
        TestName = "{m}-2")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
0 0
1 3
5 6
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
0 5
1 7
2 9
3 8
4 6
",
        @"11
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
2 5 3
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
5 9 3 0 4 8 7 5 4 0
",
        @"58
",
        TestName = "{m}-2")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
