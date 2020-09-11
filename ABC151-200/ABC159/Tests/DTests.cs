using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1 1 2 1 2";
            var output = @"2
2
3
2
3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 2 3 4";
            var output = @"0
0
0
0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
3 3 3 3 3";
            var output = @"6
6
6
6
6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"8
1 2 1 4 2 1 4 1";
            var output = @"5
7
5
7
7
5
7
5";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
