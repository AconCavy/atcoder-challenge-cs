using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2";
            var output = @"0.48148148148148148148";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 1";
            var output = @"0.25925925925925925926";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"765 573";
            var output = @"0.00147697396984624371";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -9);
        }
    }
}
