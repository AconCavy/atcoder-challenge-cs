using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
140 180 160";
            var output = @"2
3
1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
1000000000 1";
            var output = @"1
2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
3 1 4 15 9 2 6 5";
            var output = @"4
5
7
8
3
1
6
2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
