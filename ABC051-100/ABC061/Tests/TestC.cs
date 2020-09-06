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
            var input = @"3 4
1 1
2 2
3 3";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 500000
1 100000
1 100000
1 100000
1 100000
1 100000
100000 100000
100000 100000
100000 100000
100000 100000
100000 100000";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
