using Microsoft.VisualStudio.TestTools.UnitTesting;
using E;

namespace Tests
{
    [TestClass]
    public class TestE
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 2
1 2 -3 -4";
            var output = @"12";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 3
-1 -2 -3 -4";
            var output = @"1000000001";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 1
-1 1000000000";
            var output = @"1000000000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10 10
1000000000 100000000 10000000 1000000 100000 10000 1000 100 10 1";
            var output = @"999983200";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
