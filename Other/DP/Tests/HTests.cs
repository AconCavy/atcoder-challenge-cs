using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
...#
.#..
....
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 2
..
#.
..
.#
..
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5
..#..
.....
#...#
.....
..#..
";
            const string output = @"24
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"20 20
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
";
            const string output = @"345263555
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
