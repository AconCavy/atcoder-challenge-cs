using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
oof";
            var output = @"575111451";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"37564
whydidyoudesertme";
            var output = @"318008117";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
