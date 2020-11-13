using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 1 1 3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1 2 3 4";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2000000000 0 0 2000000000";
            const string output = @"2000000000";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
