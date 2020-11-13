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
3 8 5 1";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
3 8 4 1";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10
1 8 10 5 8 12 34 100 11 3";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
