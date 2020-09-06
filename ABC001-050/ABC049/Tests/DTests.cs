using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 3 1
1 2
2 3
3 4
2 3";
            var output = @"1 2 2 1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 2 2
1 2
2 3
1 4
2 3";
            var output = @"1 2 2 1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7 4 4
1 2
2 3
2 5
6 7
3 5
4 5
3 4
6 7";
            var output = @"1 1 2 1 2 2 2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
