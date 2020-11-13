using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"??2??5";
            const string output = @"768";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"?44";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"7?4";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"?6?42???8??2??06243????9??3???7258??5??7???????774????4?1??17???9?5?70???76???";
            const string output = @"153716888";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
