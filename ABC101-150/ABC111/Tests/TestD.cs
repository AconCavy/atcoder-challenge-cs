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
            var input = @"3
-1 0
0 3
2 -1";
            var output = @"2
1 2
RL
UU
DR";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
0 0
1 0
2 0
3 0
4 0";
            var output = @"-1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
1 1
1 1";
            var output = @"2
1 1
RU
UR";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3
-7 -3
7 3
-3 -7";
            var output = @"5
3 1 4 1 5
LRDUL
RDULR
DULRD";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
