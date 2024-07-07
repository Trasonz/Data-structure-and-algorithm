using CodingChallenges.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.ArrayProblems.PrefixSum
{
    internal class _15_NumberOfWaysToSplitTheArray
    {
        // Given an integer array nums, find the number of ways to split the array into two parts
        // so that the first section has a sum greater than or equal to the sum of the second section.
        // The second section should have at least one number.
        private readonly List<List<int>> _testCases =
        [
            [10, 4, -8, 7],
            [1, 1, 2]
        ];


        /*
         * Time complexity: O(n), with n is numbers.Count. 
         * Space complexity: O(1). 
         */
        public static int NumberOfWaysToSplitTheArray(List<int> numbers)
        {
            // Build the prefix sum
            var totalSum = numbers.Sum();
            var prefixSum = 0;
            var result = 0;

            // numbers.Count - 1 because we should not scan the last index
            for (var index = 0; index < numbers.Count - 1; index++)
            {
                prefixSum += numbers[index];
                var remainingSum = totalSum - prefixSum;

                if (prefixSum >= remainingSum)
                {
                    result++;
                }
            }

            return result;
        }

        public void Run()
        {
            foreach (var _testCase in _testCases)
            {
                Console.WriteLine($"The number of ways to split the array into two parts " +
                    $"so that the first section has a sum " +
                    $"greater than or equal to the sum of the second section " +
                    $"is {NumberOfWaysToSplitTheArray(_testCase)}");
            }
        }
    }
}
