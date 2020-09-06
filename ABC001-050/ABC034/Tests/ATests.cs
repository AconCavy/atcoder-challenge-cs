using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"12 34";
            var output = @"Better";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"98 56";
            var output = @"Worse";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
