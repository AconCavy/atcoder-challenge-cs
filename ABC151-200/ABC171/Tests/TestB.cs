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
            var input = @"5 3
50 100 80 120 80";
            var output = @"210";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1
1000";
            var output = @"1000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
