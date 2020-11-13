using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 3
1 4 5
2 4 9";
            var output = @"18";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 6
1 3 4 6 7 5
1 2 4 8 8 7
2 7 9 2 7 2
9 4 2 7 6 5
2 8 4 6 7 6
3 7 9 1 2 7";
            var output = @"170";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
