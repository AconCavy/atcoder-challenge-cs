using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 2
5 1 4
2 3
1 5";
            const string output = @"14";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10 3
1 8 5 7 100 4 52 33 13 5
3 10
4 30
1 4";
            const string output = @"338";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3 2
100 100 100
3 99
3 99";
            const string output = @"300";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"11 3
1 1 1 1 1 1 1 1 1 1 1
3 1000000000
4 1000000000
3 1000000000";
            const string output = @"10000000001";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
