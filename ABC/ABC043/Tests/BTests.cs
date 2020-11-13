using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"01B0";
            var output = @"00";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"0BB1";
            var output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
