using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"chokudai";
            var output = @"chokudaipp";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"sanagi";
            var output = @"sanagipp";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
