using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems;

internal static class MinStartValue
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
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [-3, 2, -3, 4, 2] },
        new() { Array1 = [1, 2]},
        new() { Array1 = [1, -2, -2]},
        new() { Array1 = [-3,6,2,5,8,6]},
    ];

    public static int CalculateMinStartValueUsingPrefixSum(int[] numbers)
    {
        int prefixSum = 0;
        int minPrefixSum = 1;

        // t: O(n)
        for (int index = 0; index < numbers.Length; index++)
        {
            prefixSum += numbers[index];

            if (prefixSum < minPrefixSum)
            {
                minPrefixSum = prefixSum;
            }
        }

        return minPrefixSum > 0
            ? 1
            : 1 - minPrefixSum;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine($"The minimum positive value of startValue such that the step by step sum " +
                $"is never less than 1 is {CalculateMinStartValueUsingPrefixSum(testCase.Array1)}");
        }
    }
}
