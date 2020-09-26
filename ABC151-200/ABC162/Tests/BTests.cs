using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"15";
            const string output = @"60";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1000000";
            const string output = @"266666333332";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
