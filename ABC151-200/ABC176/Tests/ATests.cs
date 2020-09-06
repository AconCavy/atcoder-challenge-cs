using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"20 12 6";
            var output = @"12";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1000 1 1000";
            var output = @"1000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
