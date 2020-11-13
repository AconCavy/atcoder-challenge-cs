using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
2 3 1";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
1 2 3 4 5";
            const string output = @"30";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"8
8 2 7 3 4 5 6 1";
            const string output = @"136";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
