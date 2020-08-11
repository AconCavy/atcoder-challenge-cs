using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"dog";
            var output = @"dogs";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"chokudai";
            var output = @"chokudais";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
