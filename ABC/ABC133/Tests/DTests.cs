using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
2 2 4";
            const string output = @"4 0 4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
3 8 7 5 5";
            const string output = @"2 4 12 2 8";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3
1000000000 1000000000 0";
            const string output = @"0 2000000000 0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
