using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 4
1 2
2 3
3 4
4 1
1 3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 3
1 2
2 3
3 1
1 2";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2 0
1 2";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"6 8
1 2
2 3
3 4
4 5
5 1
1 4
1 5
4 6
1 6";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
