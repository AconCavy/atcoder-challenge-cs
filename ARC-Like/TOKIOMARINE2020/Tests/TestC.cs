using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 1
1 0 0 1 0";
            var output = @"1 2 2 1 2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 2
1 0 0 1 0";
            var output = @"3 3 4 4 3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 3
1 0 0 0 0";
            var output = @"4 4 5 4 4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"5 4
1 0 0 0 0";
            var output = @"5 5 5 5 5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"5 2
3 0 0 0 0";
            var output = @"3 4 3 4 3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"5 2
0 2 0 2 0";
            var output = @"3 4 5 4 3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = @"5 10
0 0 0 0 0";
            var output = @"5 5 5 5 5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}

// 1 0 0 0 0
// 1 2 1 1 1
// 2 3 3 4 2
// 4 4 5 4 4
// 5 5 5 5 5