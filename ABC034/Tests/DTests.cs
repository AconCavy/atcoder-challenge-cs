using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2
100 15
300 20
200 30";
            var output = @"25.000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 3
16 51
51 64
61 57
4 26";
            var output = @"59.0390624999999993";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -9);
        }
    }
}
