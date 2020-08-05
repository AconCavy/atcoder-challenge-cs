using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 2 5
1 3
1 2 2
2 1 1";
            var output = @"6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 2 3
1 3
1 2 2
2 1 1";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8 15 120
1 2 6 16 1 3 11 9
1 8 1
7 3 14
8 2 13
3 5 4
5 7 5
6 4 1
6 8 17
7 8 5
1 4 2
4 7 1
6 1 3
3 1 10
2 6 5
2 4 12
5 1 30";
            var output = @"1488";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
