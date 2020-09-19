using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1900";
            var output = @"100";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3000";
            var output = @"0";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
