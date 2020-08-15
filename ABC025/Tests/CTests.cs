using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"0 15 0
0 0 25
20 10
0 0
25 0";
            var output = @"15
80";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"18 22 15
11 16 17
4 25
22 15
10 4";
            var output = @"72
107";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
