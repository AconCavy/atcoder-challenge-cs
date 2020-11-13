using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 2";
            var output = @"2 1";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 5";
            var output = @"5 5";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
