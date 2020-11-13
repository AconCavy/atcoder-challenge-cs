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
4 4 9 7 5";
            var output = @"5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
4 5 4 3 3 5";
            var output = @"8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10
9 4 6 1 9 6 10 6 6 8";
            var output = @"39";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"2
1 1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
