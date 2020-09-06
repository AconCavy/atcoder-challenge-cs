using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1500 2000 1600 3 2";
            var output = @"7900";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1500 2000 1900 3 2";
            var output = @"8500";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1500 2000 500 90000 100000";
            var output = @"100000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"2000 1500 1900 3 2";
            var output = @"9000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
