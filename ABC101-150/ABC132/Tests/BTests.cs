using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
1 3 5 4 2";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"9
9 6 3 2 5 8 7 4 1";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
