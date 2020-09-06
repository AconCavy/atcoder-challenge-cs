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
            var input = @"5 3
1 9
1 7
2 6
2 5
3 1";
            var output = @"26";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 4
1 1
2 1
3 1
4 6
4 5
4 5
4 5";
            var output = @"25";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 5
5 1000000000
2 990000000
3 980000000
6 970000000
6 960000000
4 950000000";
            var output = @"4900000016";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
