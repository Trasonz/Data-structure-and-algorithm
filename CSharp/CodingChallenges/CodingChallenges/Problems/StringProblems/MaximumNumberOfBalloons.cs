using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems;
internal class MaximumNumberOfBalloons // Balloon
{
    // Given an integer array nums, return the largest integer that only occurs once.
    // If no integer occurs once, return -1.
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "b", String2 = "bballoon" },
        new() { String1 = "nlaebolko", String2 = "balloon" },
        new() { String1 = "loonbalxballpoon", String2 = "balloon" },
        new() { String1 = "leetcode", String2 = "balloon" },
        new() { String1 = "thinhxghjtliknphqhhtn", String2 = "thinh", ExpectedInteger = 2 },
    ];

    public static int FindMaximumNumberOfExpectedStringUsingHashMap(string text, string expectedString)
    {
        Dictionary<char, int> expectedStringCharacterFractionMap = [];  // m
        Dictionary<char, int> expectedStringCharacterFrequencyMap = []; // t

        foreach (char character in expectedString)
        {
            expectedStringCharacterFractionMap[character] = expectedStringCharacterFractionMap
                .TryGetValue(character, out int value)
                ? ++value
                : 1;

            expectedStringCharacterFrequencyMap.TryAdd(character, 0);
        }

        foreach (char character in text)
        {
            if (expectedStringCharacterFrequencyMap.TryGetValue(character, out var value))
            {
                expectedStringCharacterFrequencyMap[character] = ++value;
            }
        }

        if (expectedString.Length == 1)
        {
            return expectedStringCharacterFrequencyMap.Count;
        }

        int min = expectedStringCharacterFrequencyMap.First().Value / expectedStringCharacterFractionMap.First().Value;

        if (min == 0)
        {
            return 0;
        }

        for (var index = 1; index < expectedString.Length; index++)
        {
            // Nếu tất cả các characters khi chia tỷ lệ đều bằng nhau
            // thì số tỉ lệ là số instances
            var numberOfAppearances = expectedStringCharacterFrequencyMap[expectedString[index]]
                / expectedStringCharacterFractionMap[expectedString[index]];

            if (numberOfAppearances == 0)
            {
                return 0;
            }

            if (numberOfAppearances < min)
            {
                min = numberOfAppearances;
            }
        }

        return min;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash map");

        foreach (var testCase in _testCases)
        {
            Console.WriteLine(FindMaximumNumberOfExpectedStringUsingHashMap(testCase.String1!, testCase.String2));
        }
    }
}
