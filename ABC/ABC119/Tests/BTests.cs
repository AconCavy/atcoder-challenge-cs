using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
10000 JPY
0.10000000 BTC";
            const string output = @"48000.0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
100000000 JPY
100.00000000 BTC
0.00000001 BTC";
            const string output = @"138000000.0038";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -5);
        }
    }
}
