using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 2 2 2 1
2 4
5 1
3";
            var output = @"12";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 2 2 2 2
8 6
9 1
2 1";
            var output = @"25";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 2 4 4 4
11 12 13 14
21 22 23 24
1 2 3 4";
            var output = @"74";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
