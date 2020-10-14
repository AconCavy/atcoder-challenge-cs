using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 2 9";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 2 7";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4 2 8";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
