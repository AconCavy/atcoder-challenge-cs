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
            var input = @"4 3
1 2
2 3
2 4
2 10
1 100
3 1";
            var output = @"100 110 111 110";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 2
1 2
1 3
2 4
3 6
2 5
1 10
1 10";
            var output = @"20 20 20 20 20 20";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 3
1 4
1 3
2 3
2 10
1 100
3 1";
            var output = @"100 111 101 100";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
