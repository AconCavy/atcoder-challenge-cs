using Microsoft.VisualStudio.TestTools.UnitTesting;
using E;

namespace Tests
{
    [TestClass]
    public class TestE
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 8
3 30
4 50
5 60";
            var output = @"90";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1000000000
1000000000 10";
            var output = @"10";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 15
6 5
5 6
6 4
6 6
3 5
7 2";
            var output = @"17";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
