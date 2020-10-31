using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1 2 3";
            const string output = @"18";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1000000000 987654321 123456789";
            const string output = @"951633476";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
