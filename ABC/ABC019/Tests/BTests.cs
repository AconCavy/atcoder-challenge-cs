using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"aabbbaad";
            var output = @"a2b3a2d1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"aabbbbbbbbbbbbxyza";
            var output = @"a2b12x1y1z1a1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"edcba";
            var output = @"e1d1c1b1a1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
