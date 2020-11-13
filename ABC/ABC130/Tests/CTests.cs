using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3 1 2";
            const string output = @"3 0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 2 1 1";
            const string output = @"2 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
