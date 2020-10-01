using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 4
1 4 2 3 5";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"8 4
4 2 4 2 4 2 4 2";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10 7
14 15 92 65 35 89 79 32 38 46";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
