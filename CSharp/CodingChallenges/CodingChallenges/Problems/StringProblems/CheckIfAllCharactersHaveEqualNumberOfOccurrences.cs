using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;

internal class CheckIfAllCharactersHaveEqualNumberOfOccurrences
{
    // Given a string _string,
    // return true if all the characters that appear in _string
    // have the same number of occurrences, or false otherwise.
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { Element = "abcba" },
        new() { Element = "abccba" },
    ];

    // [Tip] Use hash map
    // Time complexity: O(n + k), k is the number of unique characters
    // Space complexity: O(k)
    public static bool CheckIfAllCharactersHaveEqualNumberOfOccurrencesUsingHashMap(string _string)
    {
        Dictionary<int, int> numberFrequencyMap = [];

        foreach (var character in _string)
        {
            numberFrequencyMap[character] = numberFrequencyMap.TryGetValue(character, out int value)
                ? ++value
                : 1;
        }

        int expectedFrequency = numberFrequencyMap.First().Value;

        foreach (var frequency in numberFrequencyMap.Values)
        {
            if (frequency != expectedFrequency)
            {
                return false;
            }
        }

        return true;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash map");

        foreach (var testCase in _testCases)
        {
            Console.WriteLine(
                CheckIfAllCharactersHaveEqualNumberOfOccurrencesUsingHashMap(testCase.Element!));
        }
    }
}
