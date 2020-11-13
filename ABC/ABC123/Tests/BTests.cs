using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"29
20
7
35
120";
            const string output = @"215";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"101
86
119
108
57";
            const string output = @"481";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
