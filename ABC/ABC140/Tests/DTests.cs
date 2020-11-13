using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"6 1
LRLRRL";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"13 3
LRRLRLRRLRLLR";
            const string output = @"9";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10 1
LLLLLRRRRR";
            const string output = @"9";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"9 2
RRRLRLRLL";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
