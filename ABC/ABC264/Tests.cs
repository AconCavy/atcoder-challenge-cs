using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 6
",
            @"code
")]
        [TestCase(
            @"4 4
",
            @"o
")]
        [TestCase(
            @"1 7
",
            @"atcoder
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 5
",
            @"black
")]
        [TestCase(
            @"4 5
",
            @"white
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 5
1 2 3 4 5
6 7 8 9 10
11 12 13 14 15
16 17 18 19 20
2 3
6 8 9
16 18 19
",
            @"Yes
")]
        [TestCase(
            @"3 3
1 1 1
1 1 1
1 1 1
1 1
2
",
            @"No
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"catredo
",
            @"8
")]
        [TestCase(
            @"atcoder
",
            @"0
")]
        [TestCase(
            @"redocta
",
            @"21
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5 10
2 3
4 10
5 10
6 9
2 9
4 8
1 7
3 6
8 10
1 8
6
3
5
8
10
2
7
",
            @"4
4
2
2
2
1
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
4 3 5
2 6 7 4
0100
1011
1010
",
            @"9
")]
        [TestCase(
            @"15 20
29 27 79 27 30 4 93 89 44 88 70 75 96 3 78
39 97 12 53 62 32 38 84 49 93 53 26 13 25 2 76 32 42 34 18
01011100110000001111
10101111100010011000
11011000011010001010
00010100011111010100
11111001101010001011
01111001100101011100
10010000001110101110
01001011100100101000
11001000100101011000
01110000111011100101
00111110111110011111
10101111111011101101
11000011000111111001
00011101011110001101
01010000000001000000
",
            @"125
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
