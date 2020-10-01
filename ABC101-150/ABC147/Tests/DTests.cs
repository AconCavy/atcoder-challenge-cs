using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
1 2 3";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10
3 1 4 1 5 9 2 6 5 3";
            const string output = @"237";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10
3 14 159 2653 58979 323846 2643383 27950288 419716939 9375105820";
            const string output = @"103715602";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
