using CodingChallenges.Utilities;
using System.Diagnostics;

namespace CodingChallenges.Problems.ArrayProblems.PrefixSum;

internal class _17_KRadiusSubarrayAverages
{
    // You are given a 0-indexed array nums of n integers, and an integer k.
    // The k-radius average for a subarray of nums centered at some index i
    // with the radius k is the average of all elements in nums
    // between the indices i - k and i + k(inclusive).
    // If there are less than k elements before or after the index i,
    // then the k-radius average is -1.
    // The average of x elements is the sum of the x elements divided by x, using integer division.
    // The integer division truncates toward zero, which means losing its fractional part.
    private readonly Dictionary<int[], int> _testCases = new()
    {
        { [7, 4, 3, 9, 1, 8, 5, 2, 6], 3 },
        { [1, 1, 1], 2 },
        { [100000], 0 },
        { [100000], 0 },
        { [8], 100000 },
    };

    /*
     * Time complexity: O(n) (n + radius), with n is numbers.Length. 
     * Space complexity: O(1). 
     */
    public static int[] CalculateSubArrayWithARadiusCenterAtIndex(int[] numbers, int radius)
    {
        long[] prefixSum = new long[numbers.Length];
        int[] result = new int[numbers.Length];
        prefixSum[0] = numbers[0];

        int diameter = (radius * 2) + 1; // 1 is for including the center index

        // đường kính lớn hơn độ dài mảng thì kết quả chắc chắn là [-1, ..., -1]
        if (diameter > numbers.Length)
        {
            Array.Fill(result, -1);
            return result;
        }

        // Build the prefix sum
        for (int index = 0; index < numbers.Length; index++)
        {
            // build prefix sum
            if (index > 0)
            {
                prefixSum[index] = prefixSum[index - 1] + numbers[index];
            }

            result[index] = -1;
        }

        for (var index = radius /*0 + radius*/; index < numbers.Length - radius; index++)
        {
            int rightRadiusIndex = index + radius;
            int leftRadiusIndex = index - radius;
            long subPrefixSum = prefixSum[rightRadiusIndex] - prefixSum[leftRadiusIndex] + numbers[leftRadiusIndex];
            int average = Convert.ToInt32(subPrefixSum / diameter);
            result[index] = average;
        }

        return result;
    }

    public void Run()
    {
        foreach (var testCase in _testCases)
        {
            var stopWatch = Stopwatch.StartNew();
            var result = CalculateSubArrayWithARadiusCenterAtIndex(testCase.Key, testCase.Value);
            stopWatch.Stop();
            Console.Write($"The k-radius average is ");
            PrintUtility.PrintPrimitiveArray(result);
            Console.WriteLine($", Time elapsed: {stopWatch.ElapsedMilliseconds}");
        }
    }
}
