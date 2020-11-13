using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 3
1 2
2 3
1 4";
            var output = @"2
2
1
1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 5
1 2
2 1
1 2
2 1
1 2";
            var output = @"5
5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8 8
1 2
3 4
1 5
2 8
3 7
5 2
4 1
6 8";
            var output = @"3
3
2
2
2
1
1
2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
