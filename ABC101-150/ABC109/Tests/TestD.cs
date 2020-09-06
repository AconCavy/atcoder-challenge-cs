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
            var input = @"2 3
1 2 3
0 1 1";
            var output = @"3
1 1 1 2
1 2 1 3
2 2 2 3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 2
1 0
2 1
1 0";
            var output = @"3
1 1 1 2
1 2 2 2
3 1 3 2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 5
9 9 9 9 9";
            var output = @"2
1 1 1 2
1 3 1 4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
