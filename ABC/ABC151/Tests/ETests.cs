using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 2
1 1 3 4";
            var output = @"11";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 3
10 10 10 -10 -10 -10";
            var output = @"360";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3 1
1 1 1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10 6
1000000000 1000000000 1000000000 1000000000 1000000000 0 0 0 0 0";
            var output = @"999998537";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
