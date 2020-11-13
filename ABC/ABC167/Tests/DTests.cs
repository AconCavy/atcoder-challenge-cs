using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 5
3 2 4 1";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 727202214173249351
6 5 2 5 3 2";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"6 1000000000001
2 1 4 5 6 3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"6 10
2 3 4 2 6 1";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            const string input = @"6 5
1 3 4 5 6 1";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
