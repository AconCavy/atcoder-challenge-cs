using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"3 3
...
.#.
...";
            const string output = @"10";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"4 4
...#
....
..#.
....";
            const string output = @"84";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"8 10
..........
..........
..........
..........
..........
..........
..........
..........";
            const string output = @"13701937";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
