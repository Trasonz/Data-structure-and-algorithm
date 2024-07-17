using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal static class KRadiusSubarrayAverages
{
    // You are given a 0-indexed array nums of n integers, and an integer k.
    // The k-radius average for a subarray of nums centered at some index i
    // with the radius k is the average of all elements in nums
    // between the indices i - k and i + k(inclusive).
    // If there are less than k elements before or after the index i,
    // then the k-radius average is -1.
    // The average of x elements is the sum of the x elements divided by x, using integer division.
    // The integer division truncates toward zero, which means losing its fractional part.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfElements1 = [7, 4, 3, 9, 1, 8, 5, 2, 6], Integer1 = 3 },
    ];

    /*
     * Time complexity: O(n) (n + radius), with n is numbers.Length. 
     * Space complexity: O(n). 
     */
    public static int[] CalculateKRadiusSubArrayAverageUsingPrefixSum(int[] numbers, int radius)
    {
        int[] result = new int[numbers.Length];
        // 1 is for including the center index
        int diameter = (radius * 2) + 1;

        // đường kính lớn hơn độ dài mảng
        // thì kết quả chắc chắn là [-1, ..., -1]
        if (diameter > numbers.Length)
        {
            Array.Fill(result, -1);
            return result;
        }

        long[] prefixSum = new long[numbers.Length];
        prefixSum[0] = numbers[0];

        for (int index = 0; index < numbers.Length; index++) // t: O(n)
        {
            if (index > 0)
            {
                prefixSum[index] = prefixSum[index - 1] + numbers[index];
            }

            result[index] = -1;
        }

        // t: O(k)
        for (var index = radius; index < numbers.Length - radius; index++)
        {
            int right = index + radius;
            int left = index - radius;
            long subPrefixSum = prefixSum[right]
                - prefixSum[left] + numbers[left];
            int average = Convert.ToInt32(subPrefixSum / diameter);
            result[index] = average;
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            var result = CalculateKRadiusSubArrayAverageUsingPrefixSum(
                testCase.ArrayOfElements1, testCase.Integer1);
            Console.Write($"The k-radius average is ");
            PrintUtility.PrintPrimitiveArray(result);
        }
    }
}
