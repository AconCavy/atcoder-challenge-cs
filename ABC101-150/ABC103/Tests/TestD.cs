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
            var input = @"5 2
1 4
2 5";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9 5
1 8
2 7
3 5
4 6
7 9";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 10
1 2
1 3
1 4
1 5
2 3
2 4
2 5
3 4
3 5
4 5";
            var output = @"4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
