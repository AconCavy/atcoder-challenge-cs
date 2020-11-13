using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 7 9";
            const string output = @"win";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"13 7 2";
            const string output = @"bust";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
