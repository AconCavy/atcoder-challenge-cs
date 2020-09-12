using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"a
4
2 1 p
1
2 2 c
1";
            var output = @"cpa";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"a
6
2 2 a
2 1 b
1
2 2 c
1
1";
            var output = @"aabc";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"y
1
2 1 x";
            var output = @"xy";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
