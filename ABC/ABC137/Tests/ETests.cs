using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 3 10
1 2 20
2 3 30
1 3 45";
            const string output = @"35";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 2 10
1 2 100
2 2 100";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4 5 10
1 2 1
1 4 1
3 4 1
2 2 100
3 3 100";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
