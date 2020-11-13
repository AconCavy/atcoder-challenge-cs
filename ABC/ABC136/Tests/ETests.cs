using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3
8 20";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 10
3 5";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4 5
10 1 2 22";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"8 7
1 7 5 6 8 2 6 5";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
