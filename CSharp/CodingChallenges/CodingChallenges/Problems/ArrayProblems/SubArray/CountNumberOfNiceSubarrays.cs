using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;
internal class CountNumberOfNiceSubarrays
{
    // Given an array of integers nums and an integer k.
    // A continuous subarray is called nice if there are k odd numbers on it.
    // Return the number of nice sub-arrays.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [1,1,2,1,1], Integer1 = 3 },
        new() { Array1 = [2,4,6], Integer1 = 1 },
        new() { Array1 = [2,2,2,1,2,2,1,2,2,2], Integer1 = 2 },
    ];

    // [Tip] Use hash map
    // Time complexity: O(n)
    // Space complexity: O(n)
    public static int CountNumberOfNiceSubarraysUsingPrefixSumAndHashMap(int[] numbers, int k)
    {
        Dictionary<int, int> spottedPrefixSumMap = [];

        // case đặc biệt: cover trường hợp trải dài dành cho số trùng với k
        spottedPrefixSumMap.Add(0, 1);
        // Với những số khác, thuật toán sẽ note lại với 1 trong khi chạy vòng for lopp,
        // còn riêng case đặc biệt này phải init.

        int prefixSum = 0;
        int result = 0;

        foreach (int number in numbers)
        {
            // lưu dạng % 2 để biết số chẵn số lẻ
            prefixSum += number % 2;
            var previousPrefixSum = prefixSum - k;

            if (spottedPrefixSumMap.TryGetValue(previousPrefixSum, out var previousPrefixSumValue))
            {
                result += previousPrefixSumValue;
            }

            if (spottedPrefixSumMap.TryGetValue(prefixSum, out var prefixSumValue))
            {
                spottedPrefixSumMap[prefixSum]++;
            }
            else
            {
                spottedPrefixSumMap[prefixSum] = 1;
            }
        }

        return result;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash set");

        foreach (var testCase in _testCases)
        {
            Console.WriteLine(CountNumberOfNiceSubarraysUsingPrefixSumAndHashMap(testCase.Array1, testCase.Integer1));
        }
    }
}
