using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 10000000
10000000 10000000";
            var output = @"0.125";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100 2
3 7";
            var output = @"0.0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"11 8562174
25686522 17124348";
            var output = @"0.018174648284912";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
