namespace CodingChallenges.Problems.ArrayProblems.Unsorted.SubArray;

internal static class _10_SubArrayWithLengthKHavingMaxSum
{
    // Given an integer array nums and an integer k,
    // find the sum of the subarray with the largest sum whose length is k.
    private static readonly Dictionary<List<int>, int> _testCases = new()
    {
        { [3, -1, 4, 12, -8, 5, 6], 4 },    // max: 18
        { [1, 6, 4, 10, 8, 4, 2], 3 }       // max: 22
    };

    // [Tip] Use fixed sliding window.
    // Time complexity: O(n)
    // Space complexity: O(1).
    public static int FindSubArrayWithLengthKHavingMaxSum(this List<int> numbers, int k)
    {
        if (k > numbers.Count)
        {
            throw new ArgumentException("k is larger than the number of elements in the array");
        }

        var sum = 0;

        // Init the fixed window
        for (var index = 0; index < k; index++)
        {
            sum += numbers[index];
        }

        var maxSum = sum;

        for (var index = k; index < numbers.Count; index++)
        {
            // + new right value, - left value
            sum += numbers[index] - numbers[index - k];
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = FindSubArrayWithLengthKHavingMaxSum(testCase.Key, testCase.Value);
            Console.WriteLine($"The max sum of the sub-array with length {testCase.Value} is {result}");
        }
    }
}
