using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3 3";
            const string output = @"0 2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"500000000000 500000000000 1000000000000";
            const string output = @"0 0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
