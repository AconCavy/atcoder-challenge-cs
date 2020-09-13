using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"abcbcba";
            var output = @"21";
            Tester.InOutTest(() => Tasks.I.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"mississippi";
            var output = @"53";
            Tester.InOutTest(() => Tasks.I.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"ababacaca";
            var output = @"33";
            Tester.InOutTest(() => Tasks.I.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"aaaaa";
            var output = @"5";
            Tester.InOutTest(() => Tasks.I.Solve(), input, output);
        }
    }
}
