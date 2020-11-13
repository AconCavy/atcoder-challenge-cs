using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 4 9 0";
            const string output = @"5.00000000000000000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 4 10 40";
            const string output = @"4.56425719433005567605";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -9);
        }
    }
}
