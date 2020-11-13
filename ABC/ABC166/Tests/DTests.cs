using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"33";
            const string output = @"1 -2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1";
            const string output = @"0 -1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
