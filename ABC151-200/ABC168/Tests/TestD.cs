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
            var input = @"4 4
1 2
2 3
3 4
4 2";
            var output = @"Yes
1
2
2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 9
3 4
6 1
2 4
5 3
4 6
1 5
6 2
4 5
5 6";
            var output = @"Yes
6
5
6
1
1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
