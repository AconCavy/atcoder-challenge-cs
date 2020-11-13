using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"41 2
5 6";
            const string output = @"30";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10 2
5 6";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"11 2
5 6";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"314 15
9 26 5 35 8 9 79 3 23 8 46 2 6 43 3";
            const string output = @"9";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
