using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"AtCoder Beginner Contest";
            var output = @"ABC";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"AtCoder Snuke Contest";
            var output = @"ASC";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"AtCoder X Contest";
            var output = @"AXC";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
