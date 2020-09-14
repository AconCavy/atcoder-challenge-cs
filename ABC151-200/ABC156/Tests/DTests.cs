using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 1 3";
            var output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1000000000 141421 173205";
            var output = @"34076506";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
