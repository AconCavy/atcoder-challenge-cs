using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4
1 4 2
2
1 1 -8
2";
            const string output = @"4 2
1 -3";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
1 -1000000000 1000000000
1 -1000000000 1000000000
1 -1000000000 1000000000
2";
            const string output = @"-1000000000 3000000000";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
