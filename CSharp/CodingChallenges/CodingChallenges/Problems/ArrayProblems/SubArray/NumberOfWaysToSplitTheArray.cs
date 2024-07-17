using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal static class NumberOfWaysToSplitTheArray
{
    // Given an integer array nums, find the number of ways to split the array into two parts
    // so that the first section has a sum greater than or equal to the sum of the second section.
    // The second section should have at least one number.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfElements1 = [1, 2, 3, 4, 5] },
        new() { ArrayOfElements1 = [10, 4, -8, 7] },
        new() { ArrayOfElements1 = [1, 1, 2] },
    ];

    public static int CountNumberOfWaysToSplitTheArrayUsingTwoIterationIndicesAndPrefixSum(int[] numbers)
    {
        long totalSum = 0;
        int leftIndex = 0;
        int rightIndex = numbers.Length - 1;

        // t: O(n / 2)
        while (leftIndex <= rightIndex)
        {
            if (leftIndex == rightIndex)
            {
                totalSum += numbers[leftIndex];
                break;
            }

            totalSum += numbers[leftIndex] + numbers[rightIndex];
            leftIndex++;
            rightIndex--;
        }

        long prefixSum = 0;
        var result = 0;

        // numbers.Count - 1 because
        // we should not scan the last index
        // t: O(n)
        for (var index = 0; index < numbers.Length - 1; index++)
        {
            prefixSum += numbers[index];
            long remainingSum = totalSum - prefixSum;

            if (prefixSum >= remainingSum)
            {
                result++;
            }
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(CountNumberOfWaysToSplitTheArrayUsingTwoIterationIndicesAndPrefixSum(testCase.ArrayOfElements1));
        }
    }
}
