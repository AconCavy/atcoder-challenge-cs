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
            const string input = @"123456789
234567891
345678912
456789123
567891234
678912345
789123456
891234567
912345678
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"123456789
234567891
345678912
456789123
567891234
678912345
789123456
891234567
912345679
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"123456789
234567891
345678912
456789123
567891234
678912345
789123456
912345678
891234567
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
