using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 3 2 1
1 1
2 3
2 2";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 4 3 3
1 2
1 3
3 4
2 3
2 4
3 2";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5 5 5 1
1 1
2 2
3 3
4 4
5 5
4 2";
            const string output = @"24";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
