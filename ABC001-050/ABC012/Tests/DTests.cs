using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2
1 2 10
2 3 10";
            var output = @"10";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 5
1 2 12
2 3 14
3 4 7
4 5 9
5 1 18";
            var output = @"26";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 6
1 2 1
2 3 1
3 4 1
4 1 1
1 3 1
4 2 1";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
