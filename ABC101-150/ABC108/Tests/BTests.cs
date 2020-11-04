using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"0 0 0 1";
            const string output = @"-1 1 -1 0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 3 6 6";
            const string output = @"3 10 -1 7";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"31 -41 -59 26";
            const string output = @"-126 -64 -36 -131";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
