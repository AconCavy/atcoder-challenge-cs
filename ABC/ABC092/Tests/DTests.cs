using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 3";
            var output = @"3 3
##.
..#
#.#";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 8";
            var output = @"3 5
#.#.#
.#.#.
#.#.#";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 1";
            var output = @"4 2
..
#.
##
##";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3 14";
            var output = @"8 18
..................
..................
....##.......####.
....#.#.....#.....
...#...#....#.....
..#.###.#...#.....
.#.......#..#.....
#.........#..####.";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
