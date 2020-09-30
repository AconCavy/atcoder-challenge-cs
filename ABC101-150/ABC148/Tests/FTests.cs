using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 4 1
1 2
2 3
3 4
3 5";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 4 5
1 2
1 3
1 4
1 5";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2 1 2
1 2";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"9 6 1
1 2
2 3
3 4
4 5
5 6
4 7
7 8
8 9";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
