using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2
10000 JPY
0.10000000 BTC";
            var output = @"48000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
100000000 JPY
100.00000000 BTC
0.00000001 BTC";
            var output = @"138000000.0038";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
