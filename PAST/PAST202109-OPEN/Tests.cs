using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"600 200 100 750
",
            @"700
")]
        [TestCase(
            @"600 200 100 650
",
            @"650
")]
        [TestCase(
            @"800 200 100 900
",
            @"900
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 4
60 50 40 30 20 10
53 60 25 40
",
            @"40 60
")]
        [TestCase(
            @"3 1
1 2 3
123
",
            @"
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
2 3 3
",
            @"2
")]
        [TestCase(
            @"3 1
2 3 3
",
            @"0
")]
        [TestCase(
            @"5 2
2 3 4 2 2
",
            @"3
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 6
",
            @"Y
")]
        [TestCase(
            @"6 4
",
            @"X
")]
        [TestCase(
            @"3 5
",
            @"Z
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
2 1 2
3 4 5
",
            @"7
")]
        [TestCase(
            @"3 3
2 1 2
3 4 5
",
            @"-1
")]
        [TestCase(
            @"4 2
4 10 2 4
1 5 3 2
",
            @"4
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
10101
",
            @"1 4 3 2 5
")]
        [TestCase(
            @"4
1110
",
            @"-1
")]
        [TestCase(
            @"12
001110110010
",
            @"2 6 3 4 5 9 7 8 10 12 11 1
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 4
3 2 2
2 3 4
",
            @"6
")]
        [TestCase(
            @"2 10
4 1000000000 1000000000
6 1000000000 1000000000
",
            @"6000000000
")]
        [TestCase(
            @"5 10
3 1 4
1 5 9
2 6 5
3 5 8
9 7 9
",
            @"16
")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 5
1 2 3
1 3 2
",
            @"Yes
")]
        [TestCase(
            @"3 4
1 2 3
1 3 2
",
            @"No
")]
        [TestCase(
            @"10 15
3 8 3
5 9 3
6 7 1
7 8 1
2 8 5
2 4 5
4 9 3
1 4 5
1 10 2
",
            @"Yes
")]
        public void HTest(string input, string output)
        {
            Utility.InOutTest(Tasks.H.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
18 21 46
",
            @"23
")]
        [TestCase(
            @"5
3 5 7 11 13
",
            @"3
")]
        [TestCase(
            @"1
536870912
",
            @"68630377364883
")]
        public void ITest(string input, string output)
        {
            Utility.InOutTest(Tasks.I.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
2 2
1 4
",
            @"3
")]
        [TestCase(
            @"3 3
2 3
1 3
1 1
",
            @"4
6
")]
        [TestCase(
            @"5 6
2 2
2 1
2 1
2 3
1 2
2 3
",
            @"2
")]
        public void JTest(string input, string output)
        {
            Utility.InOutTest(Tasks.J.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 4
0010
1111
0010
0010
7 4
6 1
4 9
5 3
1 1
2 8
9 4
6 5
",
            @"49
")]
        [TestCase(
            @"3 4
0000
0000
0000
1 2
3 4
5 6
7 8
9 10
11 12
13 14
",
            @"56
")]
        [TestCase(
            @"4 3
100
100
100
111
5 4
3 2
9 8
100 1
200 50
10 9
8 6
",
            @"332
")]
        public void KTest(string input, string output)
        {
            Utility.InOutTest(Tasks.K.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2
2 -3
",
            @"2
")]
        [TestCase(
            @"5 10
1000000000 1000000000 1000000000 1000000000 1000000000
",
            @"3000000000
")]
        [TestCase(
            @"7 22
3 -1 4 -1 5 -9 2
",
            @"5
")]
        public void LTest(string input, string output)
        {
            Utility.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
