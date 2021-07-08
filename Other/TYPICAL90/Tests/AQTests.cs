using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AQTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
1 1
3 3
..#
#.#
#..
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.AQ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
2 1
2 3
#.#
...
#.#
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.AQ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 6
2 1
1 5
...#..
.#.##.
.#....
...##.
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.AQ.Solve, input, output);
        }
    }
}
