using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 6
#..#..
.....#
....#.
#.#...";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"8 8
..#...#.
....#...
##......
..###..#
...#..#.
##....#.
#...#...
###.#..#";
            const string output = @"13";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
