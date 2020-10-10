using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3
..#
#..";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 2
.#
#.";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
