using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 1
ABC";
            const string output = @"aBC";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 3
CABA";
            const string output = @"CAbA";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
