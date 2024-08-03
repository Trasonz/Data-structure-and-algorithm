using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;
internal class SubArraysSumEqualsK
{
    // Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
    // A subarray is a contiguous non-empty sequence of elements within an array.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [1,-1,3,-2,1], Integer1 = 1 },
        new() { Array1 = [1,3,-4,7,2,-2,2,-4,4], Integer1 = 3 },
        new() { Array1 = [1,-1,0], Integer1 = 0 },
        new() { Array1 = [1,1,1], Integer1 = 2 },
        new() { Array1 = [1,2,3], Integer1 = 3 },
    ];

    // [Tip] Use hash map
    // Time complexity: O(n)
    // Space complexity: O(n)
    public static int FindSubArraysSumEqualsKUsingPrefixSumAndHashMap(int[] numbers, int k)
    {
        Dictionary<int, int> spottedPrefixSumMap = [];

        // case đặc biệt: cover trường hợp trải dài dành cho số trùng với k
        // vd: 1, -1, 0
        // sẽ cover [1, -1, 0] vì thuật toán chỉ tìm ra [1, -1] và [0]
        spottedPrefixSumMap.Add(0, 1);
        // Với những số khác, thuật toán sẽ note lại với 1 trong khi chạy vòng for lopp,
        // còn riêng case đặc biệt này phải init.

        int prefixSum = 0;
        int result = 0;

        foreach (int number in numbers)
        {
            prefixSum += number;
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
            Console.WriteLine(FindSubArraysSumEqualsKUsingPrefixSumAndHashMap(testCase.Array1, testCase.Integer1));
        }
    }
}
