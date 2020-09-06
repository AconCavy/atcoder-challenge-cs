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
            var input = @"3 2
1 2
2 3";
            var output = @"POSSIBLE";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 3
1 2
2 3
3 4";
            var output = @"IMPOSSIBLE";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"100000 1
1 99999";
            var output = @"IMPOSSIBLE";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"5 5
1 3
4 5
2 3
2 4
1 4";
            var output = @"POSSIBLE";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
