using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1 3 4";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 2 3";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
