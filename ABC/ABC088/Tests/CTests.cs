using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 0 1
2 1 2
1 0 1";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 2 2
2 1 2
2 2 2";
            var output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"0 8 8
0 8 8
0 8 8";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1 8 6
2 9 7
0 7 7";
            var output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
