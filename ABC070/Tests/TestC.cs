using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2
2
3";
            var output = @"6";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
2
5
10
1000000000000000000
1000000000000000000";
            var output = @"1000000000000000000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
