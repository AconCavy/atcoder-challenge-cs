using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1";
            const string output = @"6.28318530717958623200";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"73";
            const string output = @"458.67252742410977361942";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -2);
        }
    }
}
