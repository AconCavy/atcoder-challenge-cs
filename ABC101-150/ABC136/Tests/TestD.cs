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
            var input = @"RRLRL";
            var output = @"0 1 2 1 1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"RRLLLLRLRRLL";
            var output = @"0 3 3 0 0 0 1 1 0 2 2 0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"RRRLLRLLRRRLLLLL";
            var output = @"0 0 3 2 0 2 1 0 0 0 4 4 0 0 0 0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
