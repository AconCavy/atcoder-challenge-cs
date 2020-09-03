using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
1
3
5
2
4
6";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
5
4
3
2
1";
            var output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
1
2
3
4
5
6
7";
            var output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10
1
5
6
7
8
9
2
4
10
3";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
