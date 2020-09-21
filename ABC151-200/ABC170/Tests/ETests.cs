using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6 3
8 1
6 2
9 3
1 1
2 2
1 3
4 3
2 1
1 2";
            var output = @"6
2
6";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 2
4208 1234
3056 5678
1 2020
2 2020";
            var output = @"3056
4208";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
