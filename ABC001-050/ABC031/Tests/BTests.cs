using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"300 400
3
240
350
480";
            var output = @"60
0
-1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"50 80
5
10000
50
81
80
0";
            var output = @"-1
0
-1
0
50";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
