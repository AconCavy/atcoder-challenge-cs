using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"Sunny";
            var output = @"Cloudy";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"Rainy";
            var output = @"Sunny";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
