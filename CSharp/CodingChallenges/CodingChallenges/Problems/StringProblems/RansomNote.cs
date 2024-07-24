using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StringProblems;
internal static class RansomNote
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "aa", String2 = "abca" },
    ];

    public static bool CanConstructUsingHashMap(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length)
        {
            return false;
        }

        Dictionary<int, int> characterFrequencyMap = [];

        foreach (char character in magazine)
        {
            characterFrequencyMap[character] = characterFrequencyMap
                .TryGetValue(character, out int value)
                    ? ++value
                    : 1;
        }

        foreach (char character in ransomNote)
        {
            if (characterFrequencyMap.ContainsKey(character))
            {
                characterFrequencyMap[character]--;

                if (characterFrequencyMap[character] < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(CanConstructUsingHashMap(testCase.String1!, testCase.String2));
        }
    }
}
