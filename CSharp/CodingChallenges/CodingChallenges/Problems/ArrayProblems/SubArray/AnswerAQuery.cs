using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArrayProblems.SubArray;

internal class AnswerAQuery
{
    // Given an integer array numbers, an array queries where queries[i] = [x, y]
    // and an integer limit, return a boolean array that represents the answer to each query.
    // A query is true if the sum of the subarray from x to y is less than limit,
    // or false otherwise.

    // For example, given numbers = [1, 6, 3, 2, 7, 2], queries = [[0, 3], [2, 5], [2, 4]],
    // and limit = 13, the answer is [true, false, true].
    // For each query, the subarray sums are[12, 14, 12].
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { Array1 = [1, 6, 3, 2, 7, 2], ArrayOfArrays1 = [[0, 3], [2, 5], [2, 4]], Integer1 = 13 },
        new() { Array1 = [1, 1, 1, 1, 1, 1], ArrayOfArrays1 = [[0, 3], [0, 4], [1, 5]], Integer1 = 5 }
    ];

    // Time complexity: O(n), with n is numbers.Count. 
    // Space complexity: O(1).
    public static List<bool> AnswerQueries(int[] numbers, int[][] queries, int limit)
    {
        List<int> prefixSum = [numbers[0]];
        List<bool> result = [];

        // Build the prefix sum
        for (int index = 1; index < numbers.Length; index++)
        {
            prefixSum.Add(prefixSum[index - 1] + numbers[index]);
        }

        foreach (var query in queries)
        {
            var rightIndex = query[1];
            var leftIndex = query[0];
            var sum = prefixSum[rightIndex] - prefixSum[leftIndex] + numbers[leftIndex];
            result.Add(sum < limit);
        }

        return result;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.Write($"Result: ");

            PrintUtility.PrintPrimitiveList(AnswerQueries(
                testCase.Array1,
                testCase.ArrayOfArrays1,
                testCase.Integer1));

            Console.WriteLine();
        }
    }
}
