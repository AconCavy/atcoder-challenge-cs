using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
6 7 9 10 31";
            var output = @"APPROVED";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
28 27 24";
            var output = @"DENIED";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
