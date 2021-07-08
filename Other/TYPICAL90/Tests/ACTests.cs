using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ACTests
    {
        const int TimeLimit = 4000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"100 4
27 100
8 39
83 97
24 75
";
            const string output = @"1
2
2
3
";
            Tester.InOutTest(Tasks.AC.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 5
1 2
2 2
2 3
3 3
1 2
";
            const string output = @"1
2
3
4
4
";
            Tester.InOutTest(Tasks.AC.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 10
1 3
3 5
5 7
7 9
2 4
4 6
6 8
3 5
5 7
4 6
";
            const string output = @"1
2
3
4
3
4
5
5
6
7
";
            Tester.InOutTest(Tasks.AC.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"500000 7
1 500000
500000 500000
1 500000
1 1
1 500000
500000 500000
1 500000
";
            const string output = @"1
2
3
4
5
6
7
";
            Tester.InOutTest(Tasks.AC.Solve, input, output);
        }
    }
}
