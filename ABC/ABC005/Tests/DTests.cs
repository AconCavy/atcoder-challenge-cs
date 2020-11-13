using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
3 2 1
2 2 1
1 1 1
3
1
4
9";
            var output = @"3
9
14";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
1 1 1
1 1 1
9 9 9
1
4";
            var output = @"27";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
