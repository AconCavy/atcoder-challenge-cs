using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2
2
3";
            var output = @"6";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
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
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
