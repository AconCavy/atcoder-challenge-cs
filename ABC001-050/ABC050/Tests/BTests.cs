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
2 1 4
2
1 1
2 3";
            var output = @"6
9";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
7 2 3 8 5
3
4 2
1 7
4 13";
            var output = @"19
25
30";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
