using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"aca
accc
ca";
            var output = @"A";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"abcb
aacb
bccc";
            var output = @"C";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
