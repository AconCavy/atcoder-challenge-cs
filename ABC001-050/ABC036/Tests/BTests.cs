using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
ooxx
xoox
xxxx
xxxx";
            var output = @"xxxo
xxoo
xxox
xxxx";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
