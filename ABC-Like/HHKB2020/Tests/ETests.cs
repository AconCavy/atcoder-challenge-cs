using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1 5
..#..";
            const string output = @"48";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 3
..#
#..";
            const string output = @"52";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
