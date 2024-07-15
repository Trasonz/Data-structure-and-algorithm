using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.ArrayProblems;
internal class LargestUniqueNumber
{
    // Given an integer array nums, return the largest integer that only occurs once.
    // If no integer occurs once, return -1.
    private static readonly List<TestCaseDto<int>> _testCases =
    [
        new() { ArrayOfElements = [5, 7, 3, 9, 4, 9, 8, 3, 1] },
        new() { ArrayOfElements = [9, 9, 8, 8] },
    ];

    // [Tip] Use hash map
    // Time complexity: O(n + k)
    // Space complexity: O(k)
    public static int FindLargestUniqueNumberUsingHashMap(int[] numbers)
    {
        Dictionary<int, int> numberFrequencyMap = [];

        int max = -1;

        foreach (int number in numbers)
        {
            numberFrequencyMap[number] = numberFrequencyMap.TryGetValue(number, out int value)
                ? ++value
                : 1;
        }

        foreach (var numberFrequency in numberFrequencyMap)
        {
            if (numberFrequency.Key > max && numberFrequency.Value == 1)
            {
                max = numberFrequency.Key;
            }
        }

        return max;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash set");

        foreach (var testCase in _testCases)
        {
            Console.WriteLine(FindLargestUniqueNumberUsingHashMap(testCase.ArrayOfElements));
        }
    }
}
