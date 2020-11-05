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
10 30 20";
            const string output = @"30";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1
10";
            const string output = @"10";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10
5 9 5 9 8 9 3 5 4 3";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
