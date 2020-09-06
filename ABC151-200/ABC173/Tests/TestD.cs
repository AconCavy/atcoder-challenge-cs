using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
2 2 1 3";
            var output = @"7";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
1 1 1 1 1 1 1";
            var output = @"6";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
5 4 1 1 1";
            var output = @"14";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
