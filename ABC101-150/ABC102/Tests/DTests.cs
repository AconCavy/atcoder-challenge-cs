using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
3 2 4 1 2";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10
10 71 84 33 6 47 23 25 52 64";
            const string output = @"36";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"7
1 2 3 1000000000 4 5 6";
            const string output = @"999999994";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
