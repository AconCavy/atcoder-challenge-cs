using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"xyz
abc";
            var output = @"xaybzc";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"atcoderbeginnercontest
atcoderregularcontest";
            var output = @"aattccooddeerrbreeggiunlnaerrccoonntteesstt";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
