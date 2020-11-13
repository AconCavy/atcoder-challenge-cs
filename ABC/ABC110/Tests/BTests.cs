using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 2 10 20
8 15 13
16 22";
            const string output = @"No War";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 2 -48 -1
-20 -35 -91 -23
-22 66";
            const string output = @"War";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5 3 6 8
-10 3 1 5 -100
100 6 14";
            const string output = @"War";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
