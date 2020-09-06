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
            var input = @"1";
            var output = @"6.28318530717958623200";
            Tester.InOutTest(() => Program.Solve(), input, output, -2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"73";
            var output = @"458.67252742410977361942";
            Tester.InOutTest(() => Program.Solve(), input, output, -2);
        }
    }
}
