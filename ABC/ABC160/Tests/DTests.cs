using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 2 4";
            var output = @"5
4
1
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 1 3";
            var output = @"3
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7 3 7";
            var output = @"7
8
4
2
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10 4 8";
            var output = @"10
12
10
8
4
1
0
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
