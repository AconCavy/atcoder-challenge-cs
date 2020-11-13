using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"200 300";
            const string output = @"200";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10000 0";
            const string output = @"20100";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
