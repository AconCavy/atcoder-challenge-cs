using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3661";
            var output = @"01:01:01";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"86399";
            var output = @"23:59:59";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
