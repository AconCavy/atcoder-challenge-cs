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
            var input = @"4
1 2 3 4
3
1 2
3 4
2 4";
            var output = @"11
12
16";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 1 1 1
3
1 2
2 1
3 5";
            var output = @"8
4
4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
1 2
3
1 100
2 100
100 1000";
            var output = @"102
200
2000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"2
1 3
2
1 4
3 1";
            var output = @"7
5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
