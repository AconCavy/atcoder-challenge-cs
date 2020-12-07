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
            const string input = @"3 5 R
790319030
091076399
143245946
590051196
398226115
442567154
112705290
716433235
221041645";
            const string output = @"8226";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 9 LU
206932999
471100777
973172688
108989704
246954192
399039569
944715218
003664867
219006823";
            const string output = @"2853";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 7 D
271573743
915078603
102553534
996473623
595593497
573572507
340348994
253066837
643845096";
            const string output = @"4646";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"2 2 LU
729142134
509607882
640003027
215270061
214055727
745319402
777708131
018697986
277156993";
            const string output = @"0700";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"8 7 RD
985877833
469488482
218647263
856777094
012249580
845463670
919136580
011130808
874387671";
            const string output = @"8878";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
