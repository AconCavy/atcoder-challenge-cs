using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3 2
1 2
5 4
9 2";
            var output = @"2";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9 4 1
1 5
2 4
3 3
4 2
5 1
6 2
7 3
8 4
9 5";
            var output = @"5";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3 0 1
300000000 1000000000
100000000 1000000000
200000000 1000000000";
            var output = @"3000000000";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
