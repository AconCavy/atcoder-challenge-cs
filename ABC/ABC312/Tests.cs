using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"ABC
",
            @"No
",
            TestName = "{m}-1")]
        [TestCase(
            @"FAC
",
            @"Yes
",
            TestName = "{m}-2")]
        [TestCase(
            @"XYX
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
            @"19 18
###......###......
###......###......
###..#...###..#...
..............#...
..................
..................
......###......###
......###......###
......###......###
.###..............
.###......##......
.###..............
............###...
...##.......###...
...##.......###...
.......###........
.......###........
.......###........
........#.........
",
            @"1 1
1 10
7 7
10 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"9 21
###.#...........#.###
###.#...........#.###
###.#...........#.###
....#...........#....
#########...#########
....#...........#....
....#.###...###.#....
....#.###...###.#....
....#.###...###.#....
",
            @"1 1
",
            TestName = "{m}-2")]
        [TestCase(
            @"18 18
######............
######............
######............
######............
######............
######............
..................
..................
..................
..................
..................
..................
............######
............######
............######
............######
............######
............######
",
            @"
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
110 90 120
100 80 120 10000
",
            @"110
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 2
100000 100000 100000 100000 100000
100 200
",
            @"201
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 2
100 100 100
80 120
",
            @"100
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"(???(?
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @")))))
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"??????????????(????????(??????)?????????(?(??)
",
            @"603032273
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
0 0 0 1 1 1
0 0 1 1 1 2
1 1 1 2 2 2
3 3 3 4 4 4
",
            @"1
1
0
0
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
0 0 10 10 10 20
3 4 1 15 6 10
0 9 6 1 20 10
",
            @"2
1
1
",
            TestName = "{m}-2")]
        [TestCase(
            @"8
0 0 0 1 1 1
0 0 1 1 1 2
0 1 0 1 2 1
0 1 1 1 2 2
1 0 0 2 1 1
1 0 1 2 1 2
1 1 0 2 2 1
1 1 1 2 2 2
",
            @"3
3
3
3
3
3
3
3
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"8 4
0 6
0 6
1 3
1 5
1 15
2 1
2 10
2 100
",
            @"27
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 5
1 5
1 5
1 5
1 5
1 5
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"12 6
2 2
0 1
0 9
1 3
1 5
1 3
0 4
2 1
1 8
2 1
0 1
0 4
",
            @"30
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
1 2
2 3
2 4
1 5
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"6
1 2
2 3
3 4
4 5
5 6
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"12
1 6
3 4
10 4
5 9
3 1
2 3
7 2
2 12
1 5
6 8
4 11
",
            @"91
",
            TestName = "{m}-3")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
