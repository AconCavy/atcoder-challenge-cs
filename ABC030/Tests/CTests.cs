using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 4
2 3
1 5 7
3 8 12 13";
            var output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1
1 1
1
1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 7
5 3
1 7 12 19 20 26
4 9 15 23 24 31 33";
            var output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
