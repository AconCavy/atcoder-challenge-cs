using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"36
24";
            var output = @"GREATER";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"850
3777";
            var output = @"LESS";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"9720246
22516266";
            var output = @"LESS";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"123456789012345678901234567890
234567890123456789012345678901";
            var output = @"LESS";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
