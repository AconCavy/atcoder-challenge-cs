using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
ip cc";
            const string output = @"icpc";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"8
hmhmnknk uuuuuuuu";
            const string output = @"humuhumunukunuku";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5
aaaaa aaaaa";
            const string output = @"aaaaaaaaaa";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
