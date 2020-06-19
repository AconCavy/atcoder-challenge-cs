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
            var input = @"1
3 7";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
13 13
7 11
7 11
2017 2017";
            var output = @"1
0
0
1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
1 53
13 91
37 55
19 51
73 91
13 49";
            var output = @"4
4
1
1
1
2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
