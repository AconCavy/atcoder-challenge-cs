using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 2
4 3
3 4
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
5 9 7
3 6 9
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 2
4 4
4 4
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"14 13
158 167 181 147 178 151 179 182 176 169 180 129 175 168
181 150 178 179 167 180 176 169 182 177 175 159 173
";
            const string output = @"343772227
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
