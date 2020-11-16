using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 3
0 1 W
1 2 W
5 3 B
5 4 B";
            var output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 1000
0 0 B
0 1 W";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 2
1 2 B
2 1 W
2 2 B
1 0 B
0 6 W
4 5 W";
            var output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
