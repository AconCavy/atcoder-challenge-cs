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
            var input = @"3 3 2
1 4 3
2 5 7
8 9 6
1
4 8";
            var output = @"5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 2 3
3 7
1 4
5 2
6 8
2
2 2
2 2";
            var output = @"0
0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 5 4
13 25 7 15 17
16 22 20 2 9
14 11 12 1 19
10 6 23 8 18
3 21 5 24 4
3
13 13
2 10
13 13";
            var output = @"0
5
0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
