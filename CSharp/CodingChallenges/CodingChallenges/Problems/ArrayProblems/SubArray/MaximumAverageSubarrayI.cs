using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal static class MaximumAverageSubarrayI
{
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfElements1 = [1,12,-5,-6,50,3], Integer1 = 4 },
    ];

    public static double FindSubArrayWithLengthKHavingMaxAverage(
        int[] numbers,
        int k)
    {
        double sum = 0;

        // t: O(0 to k - 1)
        for (var index = 0; index < k; index++)
        {
            sum += numbers[index];
        }

        double maxAverage = sum / k;

        // t: O(k to  n)
        for (var index = k; index < numbers.Length; index++)
        {
            // + new right value, - left value
            sum += numbers[index] - numbers[index - k];
            double average = sum / k;
            maxAverage = Math.Max(maxAverage, average);
        }

        return Math.Round(maxAverage, 5);
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = FindSubArrayWithLengthKHavingMaxAverage(testCase.ArrayOfElements1, testCase.Integer1);
            Console.WriteLine(result);
        }
    }
}
