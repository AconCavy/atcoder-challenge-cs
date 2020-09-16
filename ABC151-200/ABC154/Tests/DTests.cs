using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 3
1 2 2 4 5";
            var output = @"7.000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 1
6 6 6 6";
            var output = @"3.500000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 4
17 13 13 12 15 20 10 13 17 11";
            var output = @"32.000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }
    }
}
