using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4";
            const string output = @"8 10
1 2 0
2 3 0
3 4 0
1 5 0
2 6 0
3 7 0
4 8 0
5 6 1
6 7 1
7 8 1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5";
            const string output = @"5 7
1 2 0
2 3 1
3 4 0
4 5 0
2 4 0
1 3 3
3 5 1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
