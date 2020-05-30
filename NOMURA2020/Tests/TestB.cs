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
            var input = @"PD?D??P";
            var output = @"PDDDDDP";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"P?P?";
            var output = @"PDPD";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
