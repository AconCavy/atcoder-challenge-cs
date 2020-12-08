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
| |-|
|-| |
o    ";
            const string output = @"3";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 2
| |-| |-| |-| |-| |
|-| |-| |-| |-| |-|
            o      ";
            const string output = @"9";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 5
|
|
|
|
|
o";
            const string output = @"1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4 2
| | | |
| | | |
      o";
            const string output = @"4";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"9 8
| | | | | | | | |
|-| | |-| | |-| |
| | |-| | |-| | |
| |-| | | | | |-|
| | | |-| | | |-|
| | |-| |-| | | |
|-| | |-| | |-| |
| | | | | |-| | |
            o    ";
            const string output = @"3";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
