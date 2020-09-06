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
            var input = @"4 3
        1 2 3 4
        1 3
        2 3
        2 4";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 5
        8 6 9 1 2 1
        1 3
        4 2
        4 3
        4 6
        4 6";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
