using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"-2 0 2 0
4
1 1
-1 1
-1 -1
1 -1";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"-3 1 3 1
8
2 2
1 2
1 0
-1 0
-1 2
-2 2
-2 -1
2 -1";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
