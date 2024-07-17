using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal static class LongestSubArrayHasSumLessThanOrEqualK
{
    // Given an array of positive integers nums and an integer k,
    // find the length of the longest subarray whose sum is less than or equal to k.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfElements1 = [3, 2, 1, 3, 1, 1], Integer1 = 5 },
    ];

    public static int FindLongestSubArrayHasSumLessThanOrEqualKUsingTwoIterationIndices(
        int[] numbers,
        int k)
    {
        var leftIndex = 0;
        var sum = 0;
        var subArrayMaxLength = 0;

        for (var rightIndex = 0; rightIndex < numbers.Length; rightIndex++)
        {
            sum += numbers[rightIndex];

            // if sum > k
            while (sum > k)
            {
                sum -= numbers[leftIndex];
                leftIndex++;
            }

            int newSubArrayLength = rightIndex - leftIndex + 1;
            subArrayMaxLength = Math.Max(subArrayMaxLength, newSubArrayLength);
        }

        return subArrayMaxLength;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = FindLongestSubArrayHasSumLessThanOrEqualKUsingTwoIterationIndices(
                testCase.ArrayOfElements1,
                testCase.Integer1);

            Console.WriteLine(result);
        }
    }
}
