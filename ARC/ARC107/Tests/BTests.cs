using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 1";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2525 -425";
            const string output = @"10314607400";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
