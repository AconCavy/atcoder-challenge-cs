using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5";
            var output = @"11";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"86";
            var output = @"939587134549734843";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
