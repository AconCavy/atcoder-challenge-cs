using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
1
2
3";
            var output = @"18.8495559215";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
15
2
3
7
6
9";
            var output = @"508.938009881546";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -6);
        }
    }
}
