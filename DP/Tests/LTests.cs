using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
10 80 90 30";
            var output = @"10";
            Tester.InOutTest(() => Tasks.L.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
10 100 10";
            var output = @"-80";
            Tester.InOutTest(() => Tasks.L.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1
10";
            var output = @"10";
            Tester.InOutTest(() => Tasks.L.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10
1000000000 1 1000000000 1 1000000000 1 1000000000 1 1000000000 1";
            var output = @"4999999995";
            Tester.InOutTest(() => Tasks.L.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"6
4 2 9 7 1 5";
            var output = @"2";
            Tester.InOutTest(() => Tasks.L.Solve(), input, output);
        }
    }
}
