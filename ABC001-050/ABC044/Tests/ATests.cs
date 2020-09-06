using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
3
10000
9000";
            var output = @"48000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
3
10000
9000";
            var output = @"20000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
