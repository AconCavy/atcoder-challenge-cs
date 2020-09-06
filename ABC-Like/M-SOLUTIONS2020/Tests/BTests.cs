using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7 2 5
3";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 4 2
3";
            var output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
