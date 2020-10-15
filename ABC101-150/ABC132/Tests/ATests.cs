using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"ASSA";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"STOP";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"FFEE";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"FREE";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
