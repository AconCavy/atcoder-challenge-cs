using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 23";
            var output = @"246";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"999 999";
            var output = @"1999998";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
