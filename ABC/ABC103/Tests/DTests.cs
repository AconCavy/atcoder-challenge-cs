using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 2
1 4
2 5";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"9 5
1 8
2 7
3 5
4 6
7 9";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5 10
1 2
1 3
1 4
1 5
2 3
2 4
2 5
3 4
3 5
4 5";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
