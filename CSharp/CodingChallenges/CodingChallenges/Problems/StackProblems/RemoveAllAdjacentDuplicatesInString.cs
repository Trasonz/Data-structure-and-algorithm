using CodingChallenges.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Problems.StackProblems;
internal class RemoveAllAdjacentDuplicatesInString
{
    private static readonly List<TestCaseDto<string>> _testCases =
    [
        new() { String1 = "abbaca" },
        new() { String1 = "aabbcc" },
        new() { String1 = "leetcode" },
    ];

    public static string RemoveDuplicates(string _string) // n
    {
        StringBuilder stringBuilder = new();        

        foreach (char character in _string) {
            // stringBuilder[^1]: last char
            if (stringBuilder.Length != 0 && character == stringBuilder[^1])
            {
                // Remove the last char
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            else
            {
                stringBuilder.Append(character);
            }
        }

        return stringBuilder.ToString();
    }

    public static void Run()
    {
        foreach (var testCase in _testCases)
        {
            Console.WriteLine(RemoveDuplicates(testCase.String1));
        }
    }
}
