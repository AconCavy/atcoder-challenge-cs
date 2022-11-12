using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4 3
2 3 1 4
",
            @"2
")]
        [TestCase(
            @"5 2
3 5 1 4 2
",
            @"5
")]
        [TestCase(
            @"6 6
1 2 3 4 5 6
",
            @"6
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
H3
DA
D3
SK
",
            @"Yes
")]
        [TestCase(
            @"5
H3
DA
CK
H3
S7
",
            @"No
")]
        [TestCase(
            @"4
3H
AD
3D
KS
",
            @"No
")]
        [TestCase(
            @"5
00
AA
XX
YY
ZZ
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 4
4 3
4 10
8 3
",
            @"10
")]
        [TestCase(
            @"6
1 3
1 5
1 12
3 5
3 12
5 12
",
            @"12
")]
        [TestCase(
            @"3
500000000 600000000
600000000 700000000
700000000 800000000
",
            @"1
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"9 7
3 0 2 5 5 3 0 6 3
",
            @"11
")]
        [TestCase(
            @"1 10
4
",
            @"0
")]
        [TestCase(
            @"20 20
18 16 15 9 8 8 17 1 3 17 11 9 12 11 7 3 2 14 3 12
",
            @"99
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5 2
1 3 0
2 3 1
5 4 1
2 1 1
1 4 0
3 4
",
            @"5
")]
        [TestCase(
            @"4 4 2
4 3 0
1 2 1
1 2 0
2 1 1
2 4
",
            @"-1
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
9 6 0
0 4 0
3 0 3
",
            @"Yes
")]
        [TestCase(
            @"2 2
2 1
1 2
",
            @"No
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4 8
4 5
2 3
2 4
1 2
0 0 1 1 0
",
            @"89349064
")]
        [TestCase(
            @"8 12 20
7 6
2 6
6 4
2 1
8 5
7 2
7 5
3 7
3 5
1 8
6 3
1 4
0 0 1 1 0 0 0 0
",
            @"139119094
")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
