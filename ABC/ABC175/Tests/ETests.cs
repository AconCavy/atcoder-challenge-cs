using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 2 3
1 1 3
2 1 4
1 2 5";
            var output = @"8";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 5 5
1 1 3
2 4 20
1 2 1
1 3 4
1 4 2";
            var output = @"29";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 5 10
2 5 12
1 5 12
2 3 15
1 2 20
1 1 28
2 4 26
3 2 27
4 5 21
3 5 10
1 3 10";
            var output = @"142";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
