using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
3 4";
            const string output = @"3.5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
500 300 200";
            const string output = @"375";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5
138 138 138 138 138";
            const string output = @"138";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -5);
        }
    }
}
