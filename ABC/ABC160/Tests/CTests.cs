using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"20 3
5 10 15";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"20 3
0 5 15";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
