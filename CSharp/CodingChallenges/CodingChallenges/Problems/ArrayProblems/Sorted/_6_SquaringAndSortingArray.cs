using CodingChallenges.Extensions;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems.Sorted
{
    internal class _6_SquaringAndSortingArray
    {
        // Given a sorted integer array,
        // return an array of the squares of each number, and it is sorted.
        private readonly List<List<int>> _testCases =
        [
            [-4, -1, 0, 3, 10],
            [-7, -3, 2, 3, 11],
            [-7, -3, 2, 3, 6, 11]
        ];

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                Console.Write($"The square of array ");

                PrintUtility.PrintPrimitiveArray(_testCase);

                Console.Write($" is ");
                var result = _testCase.SquareAndSort();

                PrintUtility.PrintPrimitiveArray(result);

                Console.WriteLine();
            }
        }
    }
}
