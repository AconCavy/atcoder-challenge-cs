using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7
3 1 4 1 5 9 2";
            var output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
0 1 2 3 4 5 6 7 8 9";
            var output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1
99999";
            var output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
