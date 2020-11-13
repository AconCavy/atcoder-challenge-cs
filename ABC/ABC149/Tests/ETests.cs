using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 3
10 14 19 34 33";
            const string output = @"202";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"9 14
1 3 5 110 24 21 34 5 3";
            const string output = @"1837";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"9 73
67597 52981 5828 66249 75177 64141 40773 79105 16076";
            const string output = @"8128170";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
