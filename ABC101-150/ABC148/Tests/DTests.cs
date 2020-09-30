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
2 1 2";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
2 2 2";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10
3 1 4 1 5 9 2 6 5 3";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"1
1";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
