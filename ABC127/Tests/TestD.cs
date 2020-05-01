using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2
5 1 4
2 3
1 5";
            var output = @"14";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 3
1 8 5 7 100 4 52 33 13 5
3 10
4 30
1 4";
            var output = @"338";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3 2
100 100 100
3 99
3 99";
            var output = @"300";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"11 3
1 1 1 1 1 1 1 1 1 1 1
3 1000000000
4 1000000000
3 1000000000";
            var output = @"10000000001";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
