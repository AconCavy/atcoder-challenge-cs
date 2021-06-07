using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2
1 3 5
7 0
";
            const string output = @"o x x o
 x . x
  x .
   .
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 0
7 3 4 5 1 2 6 0 9 8

";
            const string output = @". . . .
 . . .
  . .
   .
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0 10

7 3 4 5 1 2 6 0 9 8
";
            const string output = @"o o o o
 o o o
  o o
   o
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
