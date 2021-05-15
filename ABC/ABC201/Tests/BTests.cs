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
            const string input = @"3
Everest 8849
K2 8611
Kangchenjunga 8586
";
            const string output = @"K2
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
Kita 3193
Aino 3189
Fuji 3776
Okuhotaka 3190
";
            const string output = @"Kita
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4
QCFium 2846
chokudai 2992
kyoprofriends 2432
penguinman 2390
";
            const string output = @"QCFium
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
