using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
.##
.#.
##.";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 2
#.
.#";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 4
..##
#...
###.
###.";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"5 5
.#.#.
#.#.#
.#.#.
#.#.#
.#.#.";
            var output = @"4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"5 5
..#..
..#..
#####
..#..
..#..";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"20 20
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################
####################";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
