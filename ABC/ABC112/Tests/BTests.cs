using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 70
7 60
1 80
4 50";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 3
1 1000
2 4
3 1000
4 500";
            const string output = @"TLE";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5 9
25 8
5 9
4 10
1000 1000
6 1";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
