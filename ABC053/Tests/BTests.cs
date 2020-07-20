using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"QWERTYASDFZXCV";
            var output = @"5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"ZABCZ";
            var output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"HASFJGHOGAKZZFEGA";
            var output = @"12";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
