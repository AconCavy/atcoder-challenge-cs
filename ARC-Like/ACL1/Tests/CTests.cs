using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
o..
...
o.#";
            var output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9 10
.#....o#..
.#..#..##o
.....#o.##
.###.#o..o
#.#...##.#
..#..#.###
#o.....#..
....###..o
o.......o#";
            var output = @"24";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
