using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"FTFFTFFF
4 2";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"FTFFTFFF
-2 -2";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"FF
1 0";
            var output = @"No";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"TF
1 0";
            const string output = @"No";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            const string input = @"FFTTFF
0 0";
            const string output = @"Yes";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            const string input = @"TTTT
1 0";
            const string output = @"No";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
