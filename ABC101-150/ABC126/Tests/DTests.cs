using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
1 2 2
2 3 1";
            const string output = @"0
0
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
2 5 2
2 3 10
1 3 8
3 4 2";
            const string output = @"0
0
0
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
