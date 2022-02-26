using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"8
........
........
.#.##.#.
........
........
........
........
........
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
######
######
######
######
######
######
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
..........
#..##.....
..........
..........
....#.....
....#.....
.#...#..#.
..........
..........
..........
";
            const string output = @"No
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"8
.......#
......#.
.....#..
..,.#...
...#....
..#.....
........
........
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
