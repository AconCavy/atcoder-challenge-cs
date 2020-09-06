using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 4
##.#
....
##.#
.#.#";
            var output = @"###
###
.##";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 3
#..
.#.
..#";
            var output = @"#..
.#.
..#";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 5
.....
.....
..#..
.....";
            var output = @"#";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"7 6
......
....#.
.#....
..#...
..#...
......
.#..#.";
            var output = @"..#
#..
.#.
.#.
#.#";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
