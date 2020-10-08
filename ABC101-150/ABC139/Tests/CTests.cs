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
10 4 8 7 3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"7
4 4 5 6 6 5 5";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4
1 2 3 4";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
