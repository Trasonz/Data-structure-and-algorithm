using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.ArrayProblems.Unsorted.SubArray
{
    internal class _10_SubArrayWithLengthKHavingMaxSum
    {
        // Given an integer array nums and an integer k,
        // find the sum of the subarray with the largest sum whose length is k.
        private readonly Dictionary<List<int>, int> _testCases = new()
        {
            { [3, -1, 4, 12, -8, 5, 6], 4 },    // max: 18
            { [1, 6, 4, 10, 8, 4, 2], 3 }       // max: 22
        };

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                var result = _testCase.Key.FindSubArrayWithLengthKHavingMaxSum(_testCase.Value);
                Console.WriteLine($"The max sum of the sub-array with length {_testCase.Value} is {result}");
            }
        }
    }
}
