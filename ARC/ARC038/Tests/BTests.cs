using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 3
.#.
...
";
            const string output = @"First
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 4
....
...#
....
.#..
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"11 44
............................................
............................................
............................................
.....#.....#####....####.....####....####...
....#.#....#....#..#....#...#....#..#....#..
....#.#....#....#..#.............#..#....#..
...#####...#####...#..........###....####...
...#...#...#....#..#.............#..#....#..
..#.....#..#....#..#....#...#....#..#....#..
..#.....#..#....#...####.....####....####...
............................................
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
