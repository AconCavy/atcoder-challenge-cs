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
            var input = @"5
1 3 4 5 7";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"15
13 76 46 15 50 98 93 77 31 43 84 90 6 24 14";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
