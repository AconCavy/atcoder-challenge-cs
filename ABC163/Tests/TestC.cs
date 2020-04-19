using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1 1 2 2";
            var output = @"2
2
0
0
0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
1 1 1 1 1 1 1 1 1";
            var output = @"9
0
0
0
0
0
0
0
0
0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
1 2 3 4 5 6";
            var output = @"1
1
1
1
1
1
0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
