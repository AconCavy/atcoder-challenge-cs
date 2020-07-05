using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 3 2
..#
###";
            var output = @"5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 3 4
..#
###";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 2 3
##
##";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6 6 8
..##..
.#..#.
#....#
######
#....#
#....#";
            var output = @"208";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
