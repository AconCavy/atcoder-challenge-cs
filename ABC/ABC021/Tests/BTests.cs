using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1 5
3
3 4 2";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
1 3
4
2 4 2 7";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4
1 4
3
2 1 3";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"4
1 4
3
2 4 3";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"20
1 4
12
2 3 5 7 8 9 10 11 12 15 13 14";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
