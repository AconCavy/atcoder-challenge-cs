using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
1 -3 3 9 1 6";
            var output = @"6";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
5 5 5";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
-1 10 -1 2 -1 10 -1 0";
            var output = @"-1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
