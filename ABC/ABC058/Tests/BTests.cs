using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"xyz
abc";
            var output = @"xaybzc";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"atcoderbeginnercontest
atcoderregularcontest";
            var output = @"aattccooddeerrbreeggiunlnaerrccoonntteesstt";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
