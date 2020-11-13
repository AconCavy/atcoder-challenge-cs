using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3 -10
1 2 3
3 2 1
1 2 2";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 2 -4
-2 5
100 41
100 40
-3 0
-6 -2
18 -13";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3 3 0
100 -100 0
0 100 100
100 100 100
-100 100 100";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
