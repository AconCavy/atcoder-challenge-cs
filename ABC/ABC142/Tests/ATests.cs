using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4";
            const string output = @"0.5000000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5";
            const string output = @"0.6000000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1";
            const string output = @"1.0000000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -6);
        }
    }
}
