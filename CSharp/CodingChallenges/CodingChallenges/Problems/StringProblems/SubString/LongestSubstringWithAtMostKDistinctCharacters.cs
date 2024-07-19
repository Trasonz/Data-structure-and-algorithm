using CodingChallenges.Dtos;

namespace CodingChallenges.Problems.StringProblems.SubString;

internal static class LongestSubstringWithAtMostKDistinctCharacters
{
    // Given a string s and an integer k, return the length of the longest substring of s
    // that contains at most k distinct characters.
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "eceba", Integer1 = 2 },
        new() { String1 = "aa", Integer1 = 1 },
        new() { String1 = "acccbb", Integer1 = 2 },
    ];

    /*
     * [Tip] Use two iteration indices and hash map
     * Time complexity: O(n) 
     * Space complexity: O(1). 
     */
    public static int FindLongestSubstringWithAtMostKDistinctCharactersUsingTwoIterationIndicesAndHashMap(
        string _string,
        int k)
    {
        Dictionary<char, int> characterFrequencyMap = [];
        int leftIndex = 0;
        int maxLength = 0;

        for (int rightIndex = 0; rightIndex < _string.Length; rightIndex++)
        {
            char rightCharacter = _string[rightIndex];

            characterFrequencyMap[rightCharacter] = characterFrequencyMap.TryGetValue(rightCharacter, out int value)
                ? ++value
                : 1;

            // Minimize the sliding window, remove the character if it is no longer counted.
            while (characterFrequencyMap.Count > k)
            {
                char leftCharacter = _string[leftIndex];
                characterFrequencyMap[leftCharacter]--;

                if (characterFrequencyMap[leftCharacter] == 0)
                {
                    characterFrequencyMap.Remove(leftCharacter);
                }

                leftIndex++;
            }

            maxLength = Math.Max(maxLength, rightIndex - leftIndex + 1);
        }

        return maxLength;
    }

    public static void Run()
    {
        Console.WriteLine("Use hash map");
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(
                FindLongestSubstringWithAtMostKDistinctCharactersUsingTwoIterationIndicesAndHashMap(
                    testCase.String1!,
                    testCase.Integer1));
        }
    }
}
