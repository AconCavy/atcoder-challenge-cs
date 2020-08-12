using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 2 3 4 5";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 2 3 5 8";
            var output = @"14";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
