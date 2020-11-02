using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
-1 0
0 3
2 -1";
            const string output = @"2
1 2
RL
UU
DR";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
0 0
1 0
2 0
3 0
4 0";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2
1 1
1 1";
            const string output = @"2
1 1
RU
UR";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"3
-7 -3
7 3
-3 -7";
            const string output = @"5
3 1 4 1 5
LRDUL
RDULR
DULRD";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
