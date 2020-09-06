using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 2 2
1 2 3 4 5";
            var output = @"4.500000
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 2 3
10 20 10 10";
            var output = @"15.000000
3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 1 5
1000000000000000 999999999999999 999999999999998 999999999999997 999999999999996";
            var output = @"1000000000000000.000000
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"50 1 50
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1";
            var output = @"1.000000
1125899906842623";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
