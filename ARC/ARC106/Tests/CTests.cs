using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 1";
            const string output = @"1 5
2 3
4 6
7 8
9 10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10 -10";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
