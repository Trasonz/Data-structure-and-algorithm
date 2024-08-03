using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal static class SubArraysProductLessThanK
{
    // Given an array of positive integers nums and an integer k,
    // return the number of subarrays where the product of all the elements in the subarray
    // is strictly less than k.
    // For example, given the input nums = [10, 5, 2, 6], k = 100, the answer is 8.
    // The subarrays with products less than k are:
    // [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [10, 5, 2, 6], Integer1 = 100 },
        new() { Array1 = [2, 4, 6, 8, 10, 1, 80, 4, 20], Integer1 = 80 },
    ];

    public static int FindNumberOfSubArraysHasProductLessThanKUsingTwoIterationIndices(
        int[] numbers, int k)
    {
        if (k <= 1)
        {
            return 0;
        }

        var leftIndex = 0;
        var product = 1;
        var numberOfSubArrays = 0;

        // t: O(n)
        for (var rightIndex = 0; rightIndex < numbers.Length; rightIndex++)
        {
            product *= numbers[rightIndex];

            while (product >= k)
            {
                product /= numbers[leftIndex];
                leftIndex++;
            }

            numberOfSubArrays += rightIndex - leftIndex + 1;
        }

        return numberOfSubArrays;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = FindNumberOfSubArraysHasProductLessThanKUsingTwoIterationIndices(
                testCase.Array1,
                testCase.Integer1);
            Console.WriteLine($"The number of sub-arrays with products LESS than k is {result}");
        }
    }
}
