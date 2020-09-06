using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 70
7 60
1 80
4 50";
            var output = @"4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 3
1 1000
2 4
3 1000
4 500";
            var output = @"TLE";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 9
25 8
5 9
4 10
1000 1000
6 1";
            var output = @"5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
