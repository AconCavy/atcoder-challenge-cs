using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"10
3 2
4 20
3 40
6 100";
            var output = @"140";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
5 4
9 10
3 7
3 1
2 6
4 5";
            var output = @"18";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"22
5 3
5 40
8 50
3 60
4 70
6 80";
            var output = @"210";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
