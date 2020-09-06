using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1
3
1 2 3
3
2 3 4";
            var output = @"yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1
3
1 2 3
3
2 3 5";
            var output = @"no";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1
3
1 2 3
10
1 2 3 4 5 6 7 8 9 10";
            var output = @"no";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1
3
1 2 3
3
1 2 2";
            var output = @"no";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"2
5
1 3 6 10 15
3
4 8 16";
            var output = @"yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
