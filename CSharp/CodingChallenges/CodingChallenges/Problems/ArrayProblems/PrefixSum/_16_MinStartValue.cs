using System.Collections.Generic;

namespace CodingChallenges.Problems.ArrayProblems.PrefixSum
{
    internal class _16_MinStartValue
    {
        // Given an array of integers nums, you start with an initial positive value startValue.
        // In each iteration, you calculate the step by step sum of startValue
        // plus elements in nums(from left to right).
        // Return the minimum positive value of startValue such that the step by step sum
        // is never less than 1.
        // Example: nums = [-3,2,-3,4,2]
        // with startValue = 5, no prefixsum < 1
        // (5 -3 ) = 2
        // (2 +2 ) = 4   
        // (4 -3 ) = 1
        // (1 +4 ) = 5
        // (5 +2 ) = 7
        private readonly List<List<int>> _testCases =
        [
            [-3, 2, -3, 4, 2],  // 5
            [1, 2],             // 1
            [1, -2, -2]         // 4
        ];

        /*
         * Time complexity: O(n), with n is numbers.Count. 
         * Space complexity: O(1). 
         */
        public static int CalculateMinStartValue(List<int> numbers)
        {
            List<int> prefixSum = [numbers[0]];
            int minPrefixSum = 1;

            // Build the prefix sum
            for (int index = 1; index < numbers.Count; index++)
            {
                var newPrefixSum = prefixSum[index - 1] + numbers[index];
                prefixSum.Add(newPrefixSum);

                if (newPrefixSum < minPrefixSum)
                {
                    minPrefixSum = newPrefixSum;
                }
            }

            return minPrefixSum > 0
                ? 1
                : 1 - minPrefixSum;
        }

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                Console.WriteLine($"The minimum positive value of startValue such that the step by step sum " +
                    $"is never less than 1 is {CalculateMinStartValue(_testCase)}");
            }
        }
    }
}
