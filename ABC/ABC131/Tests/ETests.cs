using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 3";
            const string output = @"7
1 2
1 3
1 4
1 5
2 3
2 4
2 5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 8";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
