using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1
2
3
2
1";
            var output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"11
3
1
4
1
5
9
2
6
5
3
5";
            var output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
