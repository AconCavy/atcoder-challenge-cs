using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"SAT";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"SUN";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
