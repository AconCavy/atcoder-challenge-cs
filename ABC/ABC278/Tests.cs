using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 2
2 7 8
",
            @"8 0 0
")]
        [TestCase(
            @"3 4
9 9 9
",
            @"0 0 0
")]
        [TestCase(
            @"9 5
1 2 3 4 5 6 7 8 9
",
            @"6 7 8 9 0 0 0 0 0
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1 23
",
            @"1 23
")]
        [TestCase(
            @"19 57
",
            @"20 0
")]
        [TestCase(
            @"20 40
",
            @"21 0
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 9
1 1 2
3 1 2
1 2 1
3 1 2
1 2 3
1 3 2
3 1 3
2 1 2
3 1 2
",
            @"No
Yes
No
No
")]
        [TestCase(
            @"2 8
1 1 2
1 2 1
3 1 2
1 1 2
1 1 2
1 1 2
2 1 2
3 1 2
",
            @"Yes
No
")]
        [TestCase(
            @"10 30
3 1 6
3 5 4
1 6 1
3 1 7
3 8 4
1 1 6
2 4 3
1 6 5
1 5 6
1 1 8
1 8 1
2 3 10
1 7 6
3 5 6
1 6 7
3 6 7
1 9 5
3 8 6
3 3 8
2 6 9
1 7 1
3 10 8
2 9 2
1 10 9
2 6 10
2 6 8
3 1 6
3 1 8
2 8 5
1 9 10
",
            @"No
No
No
No
Yes
Yes
No
No
No
Yes
Yes
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
3 1 4 1 5
6
3 2
2 3 4
3 3
1 1
2 3 4
3 3
",
            @"1
8
5
")]
        [TestCase(
            @"1
1000000000
8
2 1 1000000000
2 1 1000000000
2 1 1000000000
2 1 1000000000
2 1 1000000000
2 1 1000000000
2 1 1000000000
3 1
",
            @"8000000000
")]
        [TestCase(
            @"10
1 8 4 15 7 5 7 5 8 0
20
2 7 0
3 7
3 8
1 7
3 3
2 4 4
2 4 9
2 10 5
1 10
2 4 2
1 10
2 3 1
2 8 11
2 3 14
2 1 9
3 8
3 8
3 1
2 6 5
3 7
",
            @"7
5
7
21
21
19
10
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4 5 2 2
2 2 1 1
3 2 5 3
3 4 4 3
",
            @"4 4 3
5 3 4
")]
        [TestCase(
            @"5 6 9 3 4
7 1 5 3 9 5
4 5 4 5 1 2
6 1 6 2 9 7
4 7 1 5 8 8
3 4 3 3 5 3
",
            @"8 8 7
8 9 7
8 9 8
")]
        [TestCase(
            @"9 12 30 4 7
2 2 2 2 2 2 2 2 2 2 2 2
2 2 20 20 2 2 5 9 10 9 9 23
2 29 29 29 29 29 28 28 26 26 26 15
2 29 29 29 29 29 25 25 26 26 26 15
2 29 29 29 29 29 25 25 8 25 15 15
2 18 18 18 18 1 27 27 25 25 16 16
2 19 22 1 1 1 7 3 7 7 7 7
2 19 22 22 6 6 21 21 21 7 7 7
2 19 22 22 22 22 21 21 21 24 24 24
",
            @"21 20 19 20 18 17
20 19 18 19 17 15
21 19 20 19 18 16
21 19 19 18 19 18
20 18 18 18 19 18
18 16 17 18 19 17
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
enum
float
if
modint
takahashi
template
",
            @"First
")]
        [TestCase(
            @"10
catch
chokudai
class
continue
copy
exec
havoc
intrinsic
static
yucatec
",
            @"Second
")]
        [TestCase(
            @"16
mnofcmzsdx
lgeowlxuqm
ouimgdjxlo
jhwttcycwl
jbcuioqbsj
mdjfikdwix
jhvdpuxfil
peekycgxco
sbvxszools
xuuqebcrzp
jsciwvdqzl
obblxzjhco
ptobhnpfpo
muizaqtpgx
jtgjnbtzcl
sivwidaszs
",
            @"First
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
