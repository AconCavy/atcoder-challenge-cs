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
            const string input = @"5
chokudai
kensho
imos
yuichirw
ao";
            const string output = @"chokudai
ao
kensho
imos
yuichirw";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
dart
art";
            const string output = @"art
dart";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
