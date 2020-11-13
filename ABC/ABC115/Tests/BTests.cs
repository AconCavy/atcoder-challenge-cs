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
4980
7980
6980";
            const string output = @"15950";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
4320
4320
4320
4320";
            const string output = @"15120";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

    }
}
