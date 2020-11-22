using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 3000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"2 5
S.b.b
a.a.G
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"11 11
S##...#c...
...#d.#.#..
..........#
.#....#...#
#.....bc...
#.##......#
.......c..#
..#........
a..........
d..#...a...
.#........G
";
            const string output = @"14
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"11 11
.#.#.e#a...
.b..##..#..
#....#.#..#
.#dd..#..#.
....#...#e.
c#.#a....#.
.....#..#.e
.#....#b.#.
.#...#..#..
......#c#G.
#..S...#...
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
