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
0 1 3 8";
            var output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
1 4 9 10 15";
            var output = @"8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
