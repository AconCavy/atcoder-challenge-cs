using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 7 1
1 4 3 4 2 3 1";
            var output = @"4
2
5
3
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 7 2
1 4 3 4 2 3 1";
            var output = @"3
2
1
5
4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 20 300
9 1 2 5 8 1 9 3 5 6 4 5 4 6 8 3 2 7 9 6";
            var output = @"3
7
2
4
5
9
6
1
8
10";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
