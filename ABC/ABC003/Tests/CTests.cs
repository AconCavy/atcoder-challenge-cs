using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 2
1000 1500";
            var output = @"1000.000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 1
1000 1500";
            var output = @"750";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 5
2604 2281 3204 2264 2200 2650 2229 2461 2439 2211";
            var output = @"2820.031250000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }
    }
}
