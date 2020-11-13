using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"cabacc
abc";
            var output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"codeforces
atcoder";
            var output = @"6";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
