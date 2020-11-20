using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
0 1 3
1 0 2
3 2 0";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
0 1 3
1 0 1
3 1 0";
            var output = @"-1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
0 21 18 11 28
21 0 13 10 26
18 13 0 23 13
11 10 23 0 17
28 26 13 17 0";
            var output = @"82";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3
0 1000000000 1000000000
1000000000 0 1000000000
1000000000 1000000000 0";
            var output = @"3000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
