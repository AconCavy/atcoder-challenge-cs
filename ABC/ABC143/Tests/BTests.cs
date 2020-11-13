using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
3 1 2";
            const string output = @"11";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"7
5 0 7 8 3 3 2";
            const string output = @"312";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
