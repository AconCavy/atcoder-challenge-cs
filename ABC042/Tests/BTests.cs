using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
dxx
axx
cxx";
            var output = @"axxcxxdxx";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
