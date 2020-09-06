using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 5 2 7";
            var output = @"15";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100 600 200 300";
            var output = @"60000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
