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
1 2
2 3";
            const string output = @"2
1
2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"8
1 2
2 3
2 4
2 5
4 7
5 6
6 8";
            const string output = @"4
1
2
3
4
1
1
2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"6
1 2
1 3
1 4
1 5
1 6";
            const string output = @"5
1
2
3
4
5";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
