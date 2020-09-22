using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 4
2 2 4";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 8
9 9 9 9 9";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10 10
3 1 4 1 5 9 2 6 5 3";
            const string output = @"3296";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
