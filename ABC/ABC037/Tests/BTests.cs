using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 2
1 3 10
2 4 20";
            var output = @"10
20
20
20
0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 4
2 7 22
3 5 4
6 10 1
4 4 12";
            var output = @"0
22
4
12
4
1
1
1
1
1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
