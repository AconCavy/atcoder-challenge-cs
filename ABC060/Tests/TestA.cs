using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"rng gorilla apple";
            var output = @"YES";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"yakiniku unagi sushi";
            var output = @"NO";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"a a a";
            var output = @"YES";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"aaaaaaaaab aaaaaaaaaa aaaaaaaaab";
            var output = @"NO";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
