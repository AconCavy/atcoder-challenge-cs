using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 5
4 9
2 4";
            const string output = @"12";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 30
6 18
2 5
3 10
7 9";
            const string output = @"130";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1 100000
1000000000 100000";
            const string output = @"100000000000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
