using CodingChallenges.Extensions;

namespace CodingChallenges.Problems.ArrayProblems.Unsorted.SubArray
{
    internal class _9_NumberOfSubArraysHasProductLessThanK
    {
        // Given an array of positive integers nums and an integer k,
        // return the number of subarrays where the product of all the elements in the subarray
        // is strictly less than k.
        // For example, given the input nums = [10, 5, 2, 6], k = 100, the answer is 8.
        // The subarrays with products less than k are:
        // [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]
        private readonly Dictionary<List<int>, int> _testCases = new()
        {
            { [10, 5, 2, 6], 20 },
            { [2, 4, 6, 8, 10, 1, 80, 4, 20], 80 }
        };

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                var result = _testCase.Key.FindNumberOfSubArraysHasProductLessThanK(_testCase.Value);
                Console.WriteLine($"The number of sub-arrays with products LESS than k is {result}");
            }
        }
    }
}
