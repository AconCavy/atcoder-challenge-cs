// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Tests
// {
//     [TestClass]
//     public class CTests
//     {
//         const int TimeLimit = 2000;
//         const double RelativeError = 1e-9;

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test1()
//         {
//             const string input = @"3 2
// 0 3 4
// ";
//             const string output = @"6
// ";
//             Tester.InOutTest(Tasks.C.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test2()
//         {
//             const string input = @"3 100
// 1 1 1
// ";
//             const string output = @"7
// ";
//             Tester.InOutTest(Tasks.C.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test3()
//         {
//             const string input = @"5 7
// 10 12 15 20 30
// ";
//             const string output = @"330
// ";
//             Tester.InOutTest(Tasks.C.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test4()
//         {
//             const string input = @"7 1000000000
// 100261694256177806 55017793609323647 50568971510512136 98912633370372323 51937770757669401 50688484559490819 108712166294779912
// ";
//             const string output = @"322647718
// ";
//             Tester.InOutTest(Tasks.C.Solve, input, output);
//         }
//     }
// }
