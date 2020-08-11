using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1";
            var output = @"a
b
c";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2";
            var output = @"aa
ab
ac
ba
bb
bc
ca
cb
cc";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
