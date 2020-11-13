using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 1
1 2 1";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 5
1 2 1
2 3 2
1 3 3
4 5 4
5 6 5";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"100000 1
1 100000 100";
            const string output = @"99999";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
