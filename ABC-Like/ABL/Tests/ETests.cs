using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"8 5
3 6 2
1 4 7
3 8 3
2 2 2
4 5 1";
            const string output = @"11222211
77772211
77333333
72333333
72311333";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"200000 1
123 456 7";
            const string output = @"641437905";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
