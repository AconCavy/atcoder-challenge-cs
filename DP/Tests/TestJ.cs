using Microsoft.VisualStudio.TestTools.UnitTesting;
using J;

namespace Tests
{
    [TestClass]
    public class TestJ
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
1 1 1";
            var output = @"5.5";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1
3";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
1 2";
            var output = @"4.5";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10
1 3 2 3 3 2 3 2 1 3";
            var output = @"54.48064457488221";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }
    }
}
