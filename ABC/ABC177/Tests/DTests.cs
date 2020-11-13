using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 3
1 2
3 4
5 1";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 10
1 2
2 1
1 2
2 1
1 2
1 3
1 4
2 3
2 4
3 4";
            var output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 4
3 1
4 1
5 9
2 6";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
