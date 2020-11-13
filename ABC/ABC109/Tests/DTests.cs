using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3
1 2 3
0 1 1";
            const string output = @"3
2 2 2 3
1 1 1 2
1 3 1 2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 2
1 0
2 1
1 0";
            const string output = @"3
1 1 1 2
1 2 2 2
3 1 3 2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1 5
9 9 9 9 9";
            const string output = @"2
1 1 1 2
1 3 1 4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
