using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 2
1 3
3 1";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 2
1 1
1 1";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4 4
3 4 5 6
3 4 5 6";
            const string output = @"16";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"10 9
9 6 5 7 5 9 8 5 6 7
8 6 8 5 5 7 9 9 7";
            const string output = @"191";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            const string input = @"20 20
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1";
            const string output = @"846527861";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
