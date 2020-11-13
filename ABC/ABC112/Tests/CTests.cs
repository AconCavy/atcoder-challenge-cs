using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4
2 3 5
2 1 5
1 2 5
3 2 5";
            const string output = @"2 2 6";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
0 0 100
1 1 98";
            const string output = @"0 0 100";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3
99 1 191
100 1 192
99 0 192";
            const string output = @"100 0 193";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
