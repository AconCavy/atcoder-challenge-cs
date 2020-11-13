using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
2 4 4 0 2";
            var output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
6 4 0 2 4 0 2";
            var output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
7 5 1 1 7 3 5 3";
            var output = @"16";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
