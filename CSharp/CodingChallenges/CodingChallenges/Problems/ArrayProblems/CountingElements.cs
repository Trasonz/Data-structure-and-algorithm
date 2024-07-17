using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems;

internal static class CountingElements
{
    // Given an integer array arr, count how many elements x there are,
    // such that x + 1 is also in arr.
    // If there are duplicates in arr, count them separately.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfElements1 = [1, 2, 3] },
        new() { ArrayOfElements1 = [1, 1, 3, 3, 5, 5, 7, 7] },
        new() { ArrayOfElements1 = [1, 1, 1, 2, 2, 3] },
        new() { ArrayOfElements1 = [1, 1, 17, 2, 4, 13, 6, 5, 8, 9, 8] },
    ];

    // [Tip] Use hash set
    // Time complexity: O(n) 
    // Space complexity: O(n).
    public static int CountElementsUsingHashSet(int[] numbers)
    {
        HashSet<int> numberSet = [.. numbers];
        int count = 0;

        for (int index = 0; index < numbers.Length; index++)
        {
            if (numberSet.Contains(numbers[index] + 1))
            {
                count++;
            }
        }

        return count;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash set");
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(CountElementsUsingHashSet(testCase.ArrayOfElements1!));
        }
    }
}
