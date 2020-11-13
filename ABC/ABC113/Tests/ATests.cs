using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"81 58";
            const string output = @"110";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 54";
            const string output = @"31";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
