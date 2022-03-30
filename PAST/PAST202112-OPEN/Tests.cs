using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"150 90
100 70
",
            @"No
")]
        [TestCase(
            @"123 85
199 99
",
            @"No
")]
        [TestCase(
            @"100 100
200 50
",
            @"Yes
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
40 100
105 120
",
            @"2
")]
        [TestCase(
            @"6
1 2
1 6
1 11
1 51
1 101
1 501
",
            @"2
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"8
A AC
B WA
C AC
B AC
A AC
D AC
E AC
F AC
",
            @"1
4
3
6
7
8
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
5 10 10 12 5
10 10 5 0 10
",
            @"2 3 1 5 4
")]
        [TestCase(
            @"2
0 1000000000
0 1000000000
",
            @"2 1
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1120
",
            @"1111
")]
        [TestCase(
            @"8
",
            @"500
")]
        [TestCase(
            @"12345678901234567890
",
            @"4160
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2
###
#..
...
",
            @"5
")]
        [TestCase(
            @"5 4
###
#.#
###
",
            @"81
")]
        [TestCase(
            @"9 9
...
...
..#
",
            @"1
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 5
1 1 2
1 3 2
2 1 3
1 2 1
2 1 3
",
            @"Yes
No
")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"abc
aba
",
            @"2
")]
        [TestCase(
            @"aaaaaa
a
",
            @"0
")]
        [TestCase(
            @"abra
cadabra
",
            @"4
")]
        public void HTest(string input, string output)
        {
            Utility.InOutTest(Tasks.H.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 2
2 5 1
4 10 3
",
            @"6
")]
        [TestCase(
            @"1000000000000000000 1
1 1000000000000000000 1000000000000000000
",
            @"999999999999999999
")]
        public void ITest(string input, string output)
        {
            Utility.InOutTest(Tasks.I.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
1 1 1
2 A
",
            @"001
000
000
")]
        [TestCase(
            @"3 3
1 1 1
3 A
3 B
",
            @"000
000
001
")]
        [TestCase(
            @"4 8
2 A
1 4 2
2 A
1 2 2
3 B
3 B
3 A
1 3 1
",
            @"0000
0000
0100
0000
")]
        public void JTest(string input, string output)
        {
            Utility.InOutTest(Tasks.J.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2 1 1
1
1 2
2 3
3 2
",
            @"3
")]
        [TestCase(
            @"5 6 2 2
3 1
1 2
2 3
2 4
1 5
2 5
3 5
5 5
5 4
",
            @"2
3
")]
        public void KTest(string input, string output)
        {
            Utility.InOutTest(Tasks.K.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 10
7 5 10 3 2
",
            @"1
")]
        [TestCase(
            @"5 10
9 8 7 7 5
",
            @"1
")]
        [TestCase(
            @"11 1000000000
0 1 10 100 1000 10000 100000 1000000 10000000 100000000 1000000000
",
            @"10
")]
        [TestCase(
            @"5 10
9 10 8 7 6
",
            @"2
")]
        public void LTest(string input, string output)
        {
            Utility.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
