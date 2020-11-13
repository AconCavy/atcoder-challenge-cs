using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 6
2 1
3 4
4 10
3 4";
            var output = @"11";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 6
2 1
3 7
4 10
3 6";
            var output = @"13";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 10
1 100
1 100
1 100
1 100";
            var output = @"400";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"4 1
10 100
10 100
10 100
10 100";
            var output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
