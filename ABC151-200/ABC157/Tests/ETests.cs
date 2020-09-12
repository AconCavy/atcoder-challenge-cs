using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7
abcdbbd
6
2 3 6
1 5 z
2 1 1
1 4 a
1 7 d
2 1 7";
            var output = @"3
1
5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
abc
4
1 3 a
2 1 3
1 1 b
2 1 2";
            var output = @"2
1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
