using Microsoft.VisualStudio.TestTools.UnitTesting;
using G;

namespace Tests
{
    [TestClass]
    public class TestG
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 5
1 2
1 3
3 2
2 4
3 4";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 3
2 3
4 5
5 6";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 8
5 3
2 3
2 4
5 2
5 1
1 4
4 3
1 3";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
