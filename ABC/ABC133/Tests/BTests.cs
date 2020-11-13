using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 2
1 2
5 5
-2 8";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 4
-3 7 8 2
-12 1 10 2
-2 8 9 3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5 1
1
2
3
4
5";
            const string output = @"10";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
