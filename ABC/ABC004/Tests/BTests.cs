using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @". . . .
. o o .
. x x .
. . . .";
            var output = @". . . .
. x x .
. o o .
. . . .";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"o o x x
o o x x
x x o o
x x o o";
            var output = @"o o x x
o o x x
x x o o
x x o o";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
