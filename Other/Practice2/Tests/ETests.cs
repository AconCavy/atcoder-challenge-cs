using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 1
5 3 2
1 4 8
7 6 9";
            var output = @"19
X..
..X
.X.";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 2
10 10 1
10 10 1
1 1 10";
            var output = @"50
XX.
XX.
..X";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
