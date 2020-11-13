using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
12 5
1000 2000";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
21 -11
81234 94124 52141";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
