using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6 4
5
2 3 1 2 6 5";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 1
100000000000000000000
2 3 4 1";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8 1
1
2 3 4 5 3 2 4 5";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
