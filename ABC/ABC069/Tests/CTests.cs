using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
1 10 100";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 2 3 4";
            var output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3
1 4 1";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"2
1 1";
            var output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"6
2 7 1 8 2 8";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"5
2 2 2 2 5";
            var output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = @"2
4 2";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
