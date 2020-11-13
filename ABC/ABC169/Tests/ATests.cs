using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 5";
            const string output = @"10";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"100 100";
            const string output = @"10000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
