using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
6 9 4 2 11";
            var output = @"11 6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
100 0";
            var output = @"100 0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
