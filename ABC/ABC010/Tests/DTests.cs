using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 2 3
2 3
0 1
1 2
1 3";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 1 4
3
0 1
0 2
1 3
2 3";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 3 11
7 8 9
0 1
0 2
0 3
0 4
1 5
2 5
5 6
6 7
6 8
3 9
4 9";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6 2 6
4 5
0 1
0 2
1 3
2 3
3 4
3 5";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"4 3 3
1 2 3
1 2
1 3
2 3";
            var output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
