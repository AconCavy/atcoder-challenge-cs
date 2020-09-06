using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1000 8
1 3 4 5 6 7 8 9";
            var output = @"2000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9999 1
0";
            var output = @"9999";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"9999 1
9";
            var output = @"10000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
