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
            const string input = @"5
....#....
...##X...
..#####..
.#X#####.
#########
";
            const string output = @"....X....
...XXX...
..XX###..
.#X#####.
#########
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
.#.
#X#
";
            const string output = @".X.
#X#
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
.........#.........
........###........
.......#####.......
......#######......
.....#########.....
....###########....
...#############...
..###############..
.#################.
X#X########X#X####X
";
            const string output = @".........X.........
........XXX........
.......XXXXX.......
......XXXXXXX......
.....XXXXXXXXX.....
....XXXXXXXXXXX....
...XXX##XXXXXXXX...
..XXX####XXXXXXXX..
.XXX######XXXXX##X.
X#X########X#X####X
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
