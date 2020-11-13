using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 3
1 2
2 3
2 4
2 10
1 100
3 1";
            const string output = @"100 110 111 110";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 2
1 2
1 3
2 4
3 6
2 5
1 10
1 10";
            const string output = @"20 20 20 20 20 20";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
