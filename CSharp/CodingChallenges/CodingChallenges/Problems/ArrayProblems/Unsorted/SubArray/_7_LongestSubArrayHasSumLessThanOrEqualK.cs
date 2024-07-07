using CodingChallenges.Extensions;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems.Unsorted.SubArray
{
    internal class _7_LongestSubArrayHasSumLessThanOrEqualK
    {
        // Given an array of positive integers nums and an integer k,
        // find the length of the longest subarray whose sum is less than or equal to k.
        private readonly Dictionary<List<int>, int> _testCases = new()
        {
            { [3, 2, 1, 3, 1, 1], 5 },
            { [3, 3, 4, 2, 1, 1, 1, 1, 1, 1], 6 },
            { [3, 1, 2, 7, 4, 2, 1, 1, 5], 8 },
        };

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                Console.Write($"The length of the longest sub-array of ");

                PrintUtility.PrintPrimitiveArray(_testCase.Key);
                var result = _testCase.Key.FindLengthOfLongestSubArrayHasSumLessThanOrEqualK(_testCase.Value);

                Console.WriteLine($" having sum less than or equal {_testCase.Value} is {result}");
            }
        }
    }
}
