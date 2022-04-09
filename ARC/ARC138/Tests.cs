using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4 2
2 1 1 2
",
            @"2
")]
        [TestCase(
            @"3 1
3 2 1
",
            @"-1
")]
        [TestCase(
            @"20 13
90699850 344821203 373822335 437633059 534203117 523743511 568996900 694866636 683864672 836230375 751240939 942020833 865334948 142779837 22252499 197049878 303376519 366683358 545670804 580980054
",
            @"13
")]
        [TestCase(
            @"4 2
1 4 3 2
",
            @"2
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
0 1 1 0
",
            @"Yes
")]
        [TestCase(
            @"4
1 0 0 0
",
            @"No
")]
        [TestCase(
            @"4
0 0 0 1
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
3 4 1 2
",
            @"1 7
")]
        [TestCase(
            @"2
1 1
",
            @"0 1
")]
        [TestCase(
            @"10
716893678 779607519 555600775 393111963 950925400 636571379 912411962 44228139 15366410 2063694
",
            @"7 3996409938
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 1
",
            @"Yes
0 1 3 2 6 7 5 4
")]
        [TestCase(
            @"2 2
",
            @"No
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
