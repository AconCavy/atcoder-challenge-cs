using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 4 2
2 1 1
3 3 4";
            var output = @"9";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 4 3
2 1 1
3 3 4
1 4 2";
            var output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 10 5
1 6 1
4 1 3
6 9 4
9 4 2
3 1 3";
            var output = @"64";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
