using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10 9 10 10";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"46 4 40 5";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
