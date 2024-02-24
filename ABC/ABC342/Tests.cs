using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"yay
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"egg
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"zzzzzwz
",
        @"6
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
2 1 3
3
2 3
1 2
1 3
",
        @"2
2
1
",
        TestName = "{m}-1")]
    [TestCase(
        @"7
3 7 2 1 6 5 4
13
2 3
1 2
1 3
3 6
3 7
2 4
3 7
1 3
4 7
1 6
2 4
1 3
1 3
",
        @"3
2
3
3
3
2
3
3
7
1
2
3
3
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"7
atcoder
4
r a
t e
d v
a r
",
        @"recover
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
abc
4
a a
s k
n n
z b
",
        @"abc
",
        TestName = "{m}-2")]
    [TestCase(
        @"34
supercalifragilisticexpialidocious
20
g c
l g
g m
c m
r o
s e
a a
o f
f s
e t
t l
d v
p k
v h
x i
h n
n j
i r
s i
u a
",
        @"laklimamriiamrmrllrmlrkramrjimrial
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output, 1e-9);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
0 3 2 8 12
",
        @"6
",
        TestName = "{m}-1")]
    [TestCase(
        @"8
2 2 4 6 3 100 100 25
",
        @"7
",
        TestName = "{m}-2")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6 7
10 5 10 3 1 3
13 5 10 2 3 4
15 5 10 7 4 6
3 10 2 4 2 5
7 10 2 3 5 6
5 3 18 2 2 3
6 3 20 4 2 1
",
        @"55
56
58
60
17
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 5
1000000000 1000000000 1000000000 1000000000 1 5
5 9 2 6 2 3
10 4 1 6 2 3
1 1 1 1 3 5
3 1 4 1 5 1
",
        @"1000000000000000000
Unreachable
1
Unreachable
",
        TestName = "{m}-2")]
    [TestCase(
        @"16 20
4018 9698 2850 3026 8 11
2310 7571 7732 1862 13 14
2440 2121 20 1849 11 16
2560 5115 190 3655 5 16
1936 6664 39 8822 4 16
7597 8325 20 7576 12 5
5396 1088 540 7765 15 1
3226 88 6988 2504 13 5
1838 7490 63 4098 8 3
1456 5042 4 2815 14 7
3762 6803 5054 6994 10 9
9526 6001 61 8025 7 8
5176 6747 107 3403 1 5
2014 5533 2031 8127 8 11
8102 5878 58 9548 9 10
3788 174 3088 5950 3 13
7778 5389 100 9003 10 15
556 9425 9458 109 3 11
5725 7937 10 3282 2 9
6951 7211 8590 1994 15 12
",
        @"720358
77158
540926
255168
969295
Unreachable
369586
466218
343148
541289
42739
165772
618082
16582
591828
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
