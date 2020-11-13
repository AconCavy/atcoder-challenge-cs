using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"125";
            var output = @"176";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9999999999";
            var output = @"12656242944";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
