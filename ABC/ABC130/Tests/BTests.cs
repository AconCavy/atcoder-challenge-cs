using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 6
3 4 5";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 9
3 3 3 3";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
