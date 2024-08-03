using CodingChallenges.Dtos;
using CodingChallenges.Utilities;

namespace CodingChallenges.Problems.ArraysProblem;

internal class IntersectionOfMultipleArrays
{
    // Given a 2D integer array nums where nums[i] is a non-empty array of distinct positive integers,
    // return the list of integers that are present in each array of nums sorted in ascending order.
    // For example, given nums = [[3, 1, 2, 4, 5],[1, 2, 3, 4],[3, 4, 5, 6]],
    // return [3, 4]. 3 and 4 are the only numbers that are in all arrays.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfArrays1 = [[44, 21, 48]] },
        new() { ArrayOfArrays1 = [[3, 1, 2, 4, 5], [1, 2, 3, 4], [3, 4, 5, 6]] },
        new() { ArrayOfArrays1 = [[1, 2, 3], [4, 5, 6]] },
        new() { ArrayOfArrays1 = [[7, 34, 45, 10, 12, 27, 13],[27, 21, 45, 10, 12, 13]] },
    ];

    /*
     * [Tip] Use hash map
     * Time complexity: O(nm + mlogm) = O(m(n + logm))
     * Space complexity: O(n.m), not including the result. 
     */
    public static List<int> FindIntersectionOfMultipleArraysUsingHashMap(int[][] numberArrays)
    {
        if (numberArrays.Length == 1)
        {
            Array.Sort(numberArrays[0]);
            return [.. numberArrays[0]];
        }

        Dictionary<int, int> numberFrequencyMap = [];
        List<int> result = [];
        // O(nm)
        foreach (var array in numberArrays)
        {
            foreach (var number in array)
            {
                numberFrequencyMap[number] = numberFrequencyMap.TryGetValue(number, out int value)
                    ? ++value
                    : 1;

                // Nếu số lần xuất hiện bằng độ dài của numbers
                // thì số đó xuất hiện trong tất cả các mảng con
                if (numberFrequencyMap[number] == numberArrays.Length)
                {
                    result.Add(number);
                }
            }
        }

        result.Sort(); // O(mlogm)

        return result;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash map");

        foreach (var testCase in _testCases)
        {
            PrintUtility.PrintPrimitiveList(
                FindIntersectionOfMultipleArraysUsingHashMap(testCase.ArrayOfArrays1));
        }

        Console.WriteLine();
    }
}
