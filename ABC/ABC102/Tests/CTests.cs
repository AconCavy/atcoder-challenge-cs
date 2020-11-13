using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
2 2 3 5 5";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"9
1 2 3 4 5 6 7 8 9";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"6
6 5 4 3 2 1";
            const string output = @"18";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"7
1 1 1 1 2 3 4";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
