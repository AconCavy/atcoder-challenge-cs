using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
0 2
2 3
2 4
5 6";
            var output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1000000 1000000
1000000 1000000
0 1000000
1 1000000";
            var output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
