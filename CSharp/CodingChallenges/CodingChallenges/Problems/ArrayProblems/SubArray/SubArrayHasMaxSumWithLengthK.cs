using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal static class SubArrayHasMaxSumWithLengthK
{
    // Given an integer array nums and an integer k,
    // find the sum of the subarray with the largest sum whose length is k.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [3, -1, 4, 12, -8, 5, 6], Integer1 = 4 },
        new() { Array1 = [1, 6, 4, 10, 8, 4, 2], Integer1 = 3 },
    ];

    // [Tip] Use fixed sliding window.
    // Time complexity: O(n)
    // Space complexity: O(1).
    public static int FindSubArrayWithLengthKHavingMaxSum(int[] numbers, int k)
    {
        var sum = 0;

        // t: O(0 to k - 1)
        for (var index = 0; index < k; index++)
        {
            sum += numbers[index];
        }

        var maxSum = sum;

        // t: O(k to  n)
        for (var index = k; index < numbers.Length; index++)
        {
            // [+ new right value] and [- left value]
            sum += numbers[index] - numbers[index - k];
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = FindSubArrayWithLengthKHavingMaxSum(testCase.Array1, testCase.Integer1);
            Console.WriteLine(result);
        }
    }
}
