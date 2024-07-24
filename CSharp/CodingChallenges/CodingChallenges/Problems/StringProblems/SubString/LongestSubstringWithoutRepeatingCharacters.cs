using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StringProblems.SubString;
internal class LongestSubstringWithoutRepeatingCharacters
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "abcabcbb" },
        new() { String1 = "abacaa" },
    ];

    public static int LengthOfLongestSubstringUsingHashMap(string _string)
    {
        Dictionary<char, int> characterPositionMap = []; // s: O(k)
        int maxLength = 0;
        int left = 0;

        // t: O(n)
        for (int right = 0; right < _string.Length; right++)
        {
            if (characterPositionMap.ContainsKey(_string[right]))
            {
                left = Math.Max(characterPositionMap[_string[right]], left);
            }

            maxLength = Math.Max(maxLength, right - left + 1);
            characterPositionMap[_string[right]] = right + 1;
        }

        return maxLength;
    }


    public static void Run()
    {
        Console.WriteLine("Use hash map");

        foreach (var testCase in _testCases)
        {
            Console.WriteLine(
                LengthOfLongestSubstringUsingHashMap(testCase.String1!));
        }
    }
}
