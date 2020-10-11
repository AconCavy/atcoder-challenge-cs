using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1 3 2 4";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1 2 4 8";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
