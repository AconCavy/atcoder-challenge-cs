using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
1 2
2 3";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
100 100
10 10000
1 1000000000";
            const string output = @"9991";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
