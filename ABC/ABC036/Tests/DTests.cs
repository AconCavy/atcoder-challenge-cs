using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
2 5
1 5
2 4
3 2";
            var output = @"14";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
7 9
8 1
9 6
10 8
8 6
10 3
5 8
4 8
2 5";
            var output = @"192";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
