using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 4
1 4
3 3
6 2
8 1";
            var output = @"21";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 2
0 0
1 1
2 2
3 3";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 3
-1000000000 -1000000000
1000000000 1000000000
-999999999 999999999
999999999 -999999999";
            var output = @"3999999996000000001";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
