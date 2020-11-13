using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"RRLRL";
            const string output = @"0 1 2 1 1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"RRLLLLRLRRLL";
            const string output = @"0 3 3 0 0 0 1 1 0 2 2 0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"RRRLLRLLRRRLLLLL";
            const string output = @"0 0 3 2 0 2 1 0 0 0 4 4 0 0 0 0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
