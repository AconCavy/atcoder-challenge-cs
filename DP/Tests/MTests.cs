using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 4
1 2 3";
            var output = @"5";
            Tester.InOutTest(() => Tasks.M.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 10
9";
            var output = @"0";
            Tester.InOutTest(() => Tasks.M.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 0
0 0";
            var output = @"1";
            Tester.InOutTest(() => Tasks.M.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"4 100000
100000 100000 100000 100000";
            var output = @"665683269";
            Tester.InOutTest(() => Tasks.M.Solve(), input, output);
        }
    }
}
