using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4
6 5 6 8";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
4 5 3 5 4";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5
9 5 6 8 4";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
