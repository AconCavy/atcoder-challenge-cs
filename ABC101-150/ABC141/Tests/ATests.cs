using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"Sunny";
            const string output = @"Cloudy";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"Rainy";
            const string output = @"Sunny";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
