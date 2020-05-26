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
            var input = @"0 0 0 1";
            var output = @"-1 1 -1 0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 3 6 6";
            var output = @"3 10 -1 7";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"31 -41 -59 26";
            var output = @"-126 -64 -36 -131";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
