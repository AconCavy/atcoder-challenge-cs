using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4";
            var output = @"0.5000000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5";
            var output = @"0.6000000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1";
            var output = @"1.0000000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }
    }
}
