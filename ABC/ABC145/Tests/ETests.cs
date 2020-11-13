using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 60
10 10
100 100";
            const string output = @"110";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 60
10 10
10 20
10 30";
            const string output = @"60";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3 60
30 10
30 20
30 30";
            const string output = @"50";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"10 100
15 23
20 18
13 17
24 12
18 29
19 27
23 21
18 20
27 15
22 25";
            const string output = @"145";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
