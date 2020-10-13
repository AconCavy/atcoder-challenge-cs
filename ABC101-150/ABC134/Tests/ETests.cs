using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
2
1
4
5
3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
0
0
0
0";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
