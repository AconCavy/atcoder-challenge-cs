using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 1";
            const string output = @"1 3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"7 3";
            const string output = @"1 7
2 6
3 5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
