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
2 3
1 3
1 2";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
2 3 4
1 3 4
4 1 2
3 1 2";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3
2 3
3 1
1 2";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
