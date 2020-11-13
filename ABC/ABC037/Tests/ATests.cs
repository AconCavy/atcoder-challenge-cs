using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 5 6";
            var output = @"2";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"8 6 20";
            var output = @"3";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
