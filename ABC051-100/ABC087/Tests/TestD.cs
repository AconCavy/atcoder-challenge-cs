using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
1 2 1
2 3 1
1 3 2";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 3
1 2 1
2 3 1
1 3 5";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 3
2 1 1
2 3 5
3 4 2";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10 3
8 7 100
7 9 100
9 8 100";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"100 0";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"5 5
1 2 0
2 5 0
4 2 2
3 5 2
5 1 0";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = @"3 3
3 1 10000
2 1 5000
3 2 5000";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var input = @"10 6
1 5 100
3 5 1
2 3 10
4 6 100000
6 7 1
7 3 10";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
