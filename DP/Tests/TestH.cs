using Microsoft.VisualStudio.TestTools.UnitTesting;
using H;

namespace Tests
{
    [TestClass]
    public class TestH
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 4
...#
.#..
....";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 2
..
#.
..
.#
..";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 5
..#..
.....
#...#
.....
..#..";
            var output = @"24";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"20 20
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
....................";
            var output = @"345263555";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
