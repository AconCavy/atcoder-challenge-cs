using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 20 2 10";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1 1000000000000000000 10 1000000000";
            const string output = @"1000000007";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
