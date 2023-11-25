using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
        @"4
10 30 40 20
",
        @"30
",
        TestName = "{m}-1")]
        [TestCase(
        @"2
10 10
",
        @"0
",
        TestName = "{m}-2")]
        [TestCase(
        @"6
30 10 60 10 60 50
",
        @"40
",
        TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
10 30 40 50 20
",
            @"30
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 1
10 20 10
",
            @"20
",
            TestName = "{m}-2")]
        [TestCase(
            @"2 100
10 10
",
            @"0
",
            TestName = "{m}-3")]
        [TestCase(
            @"10 4
40 10 20 70 80 10 20 70 80 60
",
            @"40
",
            TestName = "{m}-4")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
10 40 70
20 50 80
30 60 90
",
            @"210
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
100 10 1
",
            @"100
",
            TestName = "{m}-2")]
        [TestCase(
            @"7
6 7 8
8 8 3
2 5 2
7 8 6
4 6 8
2 3 4
7 5 1
",
            @"46
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 8
3 30
4 50
5 60
",
            @"90
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 5
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
",
            @"5000000000
",
            TestName = "{m}-2")]
        [TestCase(
            @"6 15
6 5
5 6
6 4
6 6
3 5
7 2
",
            @"17
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 8
3 30
4 50
5 60
",
            @"90
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 1000000000
1000000000 10
",
            @"10
",
            TestName = "{m}-2")]
        [TestCase(
            @"6 15
6 5
5 6
6 4
6 6
3 5
7 2
",
            @"17
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"axyb
abyxb
",
            @"axb
",
            TestName = "{m}-1")]
        [TestCase(
            @"aa
xayaz
",
            @"aa
",
            TestName = "{m}-2")]
        [TestCase(
            @"a
z
",
            @"
",
            TestName = "{m}-3")]
        [TestCase(
            @"abracadabra
avadakedavra
",
            @"aaadara
",
            TestName = "{m}-4")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 5
1 2
1 3
3 2
2 4
3 4
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"6 3
2 3
4 5
5 6
",
            @"2
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 8
5 3
2 3
2 4
5 2
5 1
1 4
4 3
1 3
",
            @"3
",
            TestName = "{m}-3")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
...#
.#..
....
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 2
..
#.
..
.#
..
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 5
..#..
.....
#...#
.....
..#..
",
            @"24
",
            TestName = "{m}-3")]
        [TestCase(
            @"20 20
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
",
            @"345263555
",
            TestName = "{m}-4")]
        public void HTest(string input, string output)
        {
            Utility.InOutTest(Tasks.H.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
0.30 0.60 0.80
",
            @"0.612
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
0.50
",
            @"0.5
",
            TestName = "{m}-2")]
        [TestCase(
            @"5
0.42 0.01 0.42 0.99 0.42
",
            @"0.3821815872
",
            TestName = "{m}-3")]
        public void ITest(string input, string output)
        {
            Utility.InOutTest(Tasks.I.Solve, input, output, 1e-9);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 1 1
",
            @"5.5
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
3
",
            @"3
",
            TestName = "{m}-2")]
        [TestCase(
            @"2
1 2
",
            @"4.5
",
            TestName = "{m}-3")]
        [TestCase(
            @"10
1 3 2 3 3 2 3 2 1 3
",
            @"54.48064457488221
",
            TestName = "{m}-4")]
        public void JTest(string input, string output)
        {
            Utility.InOutTest(Tasks.J.Solve, input, output, 1e-9);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 4
2 3
",
            @"First
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 5
2 3
",
            @"Second
",
            TestName = "{m}-2")]
        [TestCase(
            @"2 7
2 3
",
            @"First
",
            TestName = "{m}-3")]
        [TestCase(
            @"3 20
1 2 3
",
            @"Second
",
            TestName = "{m}-4")]
        [TestCase(
            @"3 21
1 2 3
",
            @"First
",
            TestName = "{m}-5")]
        [TestCase(
            @"1 100000
1
",
            @"Second
",
            TestName = "{m}-6")]
        public void KTest(string input, string output)
        {
            Utility.InOutTest(Tasks.K.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
10 80 90 30
",
            @"10
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
10 100 10
",
            @"-80
",
            TestName = "{m}-2")]
        [TestCase(
            @"1
10
",
            @"10
",
            TestName = "{m}-3")]
        [TestCase(
            @"10
1000000000 1 1000000000 1 1000000000 1 1000000000 1 1000000000 1
",
            @"4999999995
",
            TestName = "{m}-4")]
        [TestCase(
            @"6
4 2 9 7 1 5
",
            @"2
",
            TestName = "{m}-5")]
        public void LTest(string input, string output)
        {
            Utility.InOutTest(Tasks.L.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
1 2 3
",
            @"5
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 10
9
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"2 0
0 0
",
            @"1
",
            TestName = "{m}-3")]
        [TestCase(
            @"4 100000
100000 100000 100000 100000
",
            @"665683269
",
            TestName = "{m}-4")]
        public void MTest(string input, string output)
        {
            Utility.InOutTest(Tasks.M.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
10 20 30 40
",
            @"190
",
            TestName = "{m}-1")]
        [TestCase(
            @"5
10 10 10 10 10
",
            @"120
",
            TestName = "{m}-2")]
        [TestCase(
            @"3
1000000000 1000000000 1000000000
",
            @"5000000000
",
            TestName = "{m}-3")]
        [TestCase(
            @"6
7 6 8 6 1 1
",
            @"68
",
            TestName = "{m}-4")]
        public void NTest(string input, string output)
        {
            Utility.InOutTest(Tasks.N.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 100
1 2
2 3
",
            @"3
4
3
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 100
1 2
1 3
1 4
",
            @"8
5
5
5
",
            TestName = "{m}-2")]
        [TestCase(
            @"1 100
",
            @"1
",
            TestName = "{m}-3")]
        [TestCase(
            @"10 2
8 5
10 8
6 5
1 5
4 8
2 10
3 6
9 2
1 7
",
            @"0
0
1
1
1
0
1
0
1
1
",
            TestName = "{m}-4")]
        public void VTest(string input, string output)
        {
            Utility.InOutTest(Tasks.V.Solve, input, output);
        }
    }
}
