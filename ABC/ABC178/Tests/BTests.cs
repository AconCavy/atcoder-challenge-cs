using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 2 1 1";
            var output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 5 -4 -2";
            var output = @"-6";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"-1000000000 0 -1000000000 0";
            var output = @"1000000000000000000";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
