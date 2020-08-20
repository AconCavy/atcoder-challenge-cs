using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 3 10
S##
.#G";
            var output = @"8";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 4 7
S##G
.##.
..#.";
            var output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 4 1000000000
S###
####
####
###G";
            var output = @"199999999";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"4 6 100
...###
.#....
.S####
.####G";
            var output = @"90";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
